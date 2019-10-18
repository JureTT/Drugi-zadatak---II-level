using Drugi_zadatak___II_level.Models;
using PoslovnaLogika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using PoslovnaLogika.Models;
using Filter = PoslovnaLogika.Models.Filter;

namespace Drugi_zadatak___II_level.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }
        // GET: Web
        public ActionResult List(int? brIspisa, int? strana, string sortiraj, string naziv, int? idMarke)
        {
            VoziloServis Servis = new VoziloServis();
            Mape Mapa = new Mape();
            IPagedList<IVoziloVM> lstVozilaVM = null;
            IPagedList<IVozilo> lstVozila = null;
            ViewBag.sortId = (String.IsNullOrEmpty(sortiraj)) ? "D_Id" : (sortiraj == "A_Id") ? "D_Id" : "A_Id";
            ViewBag.sortNazivMarke = (sortiraj == "A_NazivMarke") ? "D_NazivMarke" : "A_NazivMarke";
            ViewBag.sortNazivModela = (sortiraj == "A_NazivModela") ? "D_NazivModela" : "A_NazivModela";
            ViewBag.sortKratica = (sortiraj == "A_Kratica") ? "D_Kratica" : "A_Kratica";
            Sorter sorter = new Sorter(sortiraj ?? "A_Id");
            Filter filter = new Filter(naziv, idMarke);
            Numerer stranica = new Numerer();
            stranica.Str = strana ?? 1;
            stranica.BrRedova = brIspisa ?? 10;
            IOdgovor<IVoziloVM> odgovor = new Odgovor<IVoziloVM>();
            IList<IVoziloModel> lstVozilaModel = null;
            
            try
            {
                if (naziv != null || sortiraj != null || strana != null)
                {
                    lstVozilaModel = Servis.DohvatiVozila(sorter, filter, stranica);
                    lstVozila = Mapa.maper.Map<IList<IVoziloModel>, IList<IVozilo>>(lstVozilaModel).ToPagedList(stranica.Str, stranica.BrRedova); 
                    odgovor.UkupanBroj = lstVozila.TotalItemCount;
                    lstVozilaVM = new StaticPagedList<IVoziloVM>(Mapa.maper.Map<IEnumerable<IVozilo>, IEnumerable<IVoziloVM>>(lstVozila), lstVozila.GetMetaData());
                    odgovor.ListaIspisa = lstVozilaVM;
                }
                else
                {
                    lstVozilaModel = Servis.DohvatiVozila();
                    lstVozila = Mapa.maper.Map<IList<IVoziloModel>, IList<IVozilo>>(lstVozilaModel).ToPagedList(stranica.Str, stranica.BrRedova);
                    odgovor.UkupanBroj = lstVozila.Count();
                    lstVozilaVM = new StaticPagedList<IVoziloVM>(Mapa.maper.Map<IEnumerable<IVozilo>, IEnumerable<IVoziloVM>>(lstVozila), lstVozila.GetMetaData());
                    odgovor.ListaIspisa = lstVozilaVM;

                }
                ViewBag.stranica = stranica;
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa vozila. Opis: " + ex.Message;
            }
            return View(odgovor);
        }
    }
}