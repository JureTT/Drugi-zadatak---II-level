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
            IVoziloServis Servis = new VoziloServis();
            Mape Mapa = new Mape();
            IPagedList<VoziloVM> lstVozilaVM = null;
            IPagedList<IVozilo> lstVozila = null;
            ViewBag.sortId = (String.IsNullOrEmpty(sortiraj)) ? "D_Id" : (sortiraj == "A_Id") ? "D_Id" : "A_Id";
            ViewBag.sortNazivMarke = (sortiraj == "A_NazivMarke") ? "D_NazivMarke" : "A_NazivMarke";
            ViewBag.sortNazivModela = (sortiraj == "A_NazivModela") ? "D_NazivModela" : "A_NazivModela";
            ViewBag.sortKratica = (sortiraj == "A_Kratica") ? "D_Kratica" : "A_Kratica";
            ISorter sorter = new Sorter(sortiraj ?? "A_Id");
            IFilter filter = new Filter(naziv, idMarke);
            INumerer stranica = new Numerer();
            stranica.Str = strana ?? 1;
            stranica.BrRedova = brIspisa ?? 10;
            IOdgovor<VoziloVM> odgovor = new Odgovor<VoziloVM>();
            IList<IVoziloModel> lstVozilaModel = null;
            
            try
            {
                lstVozilaModel = Servis.DohvatiVozila(sorter, filter, stranica);
                lstVozila = Mapa.maper.Map<IList<IVoziloModel>, IList<IVozilo>>(lstVozilaModel).ToPagedList(stranica.Str, stranica.BrRedova); 
                odgovor.UkupanBroj = lstVozila.TotalItemCount;
                lstVozilaVM = new StaticPagedList<VoziloVM>(Mapa.maper.Map<IEnumerable<IVozilo>, IEnumerable<VoziloVM>>(lstVozila), lstVozila.GetMetaData());
                odgovor.ListaIspisa = lstVozilaVM;
               
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