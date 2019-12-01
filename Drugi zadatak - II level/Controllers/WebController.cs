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
using System.Net;

namespace Drugi_zadatak___II_level.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Index()
        {
            string poruka = "Stranica koju tražite ne postoji";
            HttpStatusCode status = HttpStatusCode.NotFound;
            return new HttpStatusCodeResult(status, poruka);
        }
        // GET: Web
        public ActionResult List(int? brIspisa, int? strana, string sortiraj, string naziv, int? idMarke)
        {
            IVoziloServis Servis = new VoziloServis();
            Mape Mapa = new Mape();
            ViewBag.sortId = (String.IsNullOrEmpty(sortiraj)) ? "D_Id" : (sortiraj == "A_Id") ? "D_Id" : "A_Id";
            ViewBag.sortNazivMarke = (sortiraj == "A_NazivMarke") ? "D_NazivMarke" : "A_NazivMarke";
            ViewBag.sortNazivModela = (sortiraj == "A_NazivModela") ? "D_NazivModela" : "A_NazivModela";
            ViewBag.sortKratica = (sortiraj == "A_Kratica") ? "D_Kratica" : "A_Kratica";
            ISorter sorter = new Sorter(sortiraj ?? "A_Id");
            IFilter filter = new Filter(naziv, idMarke);
            INumerer stranica = new Numerer();
            stranica.Str = strana ?? 1;
            brIspisa = (brIspisa < 1) ? 10 : brIspisa;
            stranica.BrRedova = brIspisa ?? 10;
            IOdgovor<VoziloModelVM> odgovor = new Odgovor<VoziloModelVM>();
            IPagedList<IVoziloModel> lstVozila = null;
            IPagedList<VoziloModelVM> lstVozilaVM = null;
            
            try
            {                
                lstVozila = Servis.DohvatiModele(sorter, filter, stranica);
                lstVozilaVM = new StaticPagedList<VoziloModelVM>(
                    Mapa.maper.Map<IEnumerable<IVoziloModel>, IEnumerable<VoziloModelVM>>(lstVozila),
                    lstVozila.GetMetaData());

                odgovor.ListaIspisa = lstVozilaVM;

                ViewBag.stranica = stranica;
            }
            catch (Exception ex)
            {
                string poruka = "Greška kod dohvaćanja popisa vozila. Opis: " + ex.Message;
                HttpStatusCode status = HttpStatusCode.InternalServerError;
                return new HttpStatusCodeResult(status, poruka);
            }
            return View(odgovor);
        }
    }
}