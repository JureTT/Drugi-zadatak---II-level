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
            stranica.UnesiBrStr(strana ?? 1);
            stranica.UnesiBrRedova(brIspisa);
            IOdgovor odgovor = new Odgovor();

            try
            {
                if (naziv != null || sortiraj != null || strana != null)
                {
                    odgovor = Servis.DohvatiVozila(sorter, filter, stranica);
                    //lstVozilaVM = new StaticPagedList<IVoziloVM>(Mapa.maper.Map<IEnumerable<IVozilo>, IEnumerable<IVoziloVM>>(lstVozila), lstVozila.GetMetaData());
                }
                else
                {
                    lstVozila = Servis.DohvatiVozila().ToPagedList<IVozilo>(stranica.Str, stranica.BrRedova);
                    odgovor.Redovi = lstVozila.Count();
                    //lstVozilaVM = new StaticPagedList<IVoziloVM>(Mapa.maper.Map<IEnumerable<IVozilo>, IEnumerable<IVoziloVM>>(lstVozila), lstVozila.GetMetaData());
                    odgovor.ListaIspisa = lstVozila;

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