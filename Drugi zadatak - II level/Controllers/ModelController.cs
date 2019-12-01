using Drugi_zadatak___II_level.Models;
using PoslovnaLogika.Models;
using PoslovnaLogika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Filter = PoslovnaLogika.Models.Filter;
using System.Net;

namespace Drugi_zadatak___II_level.Controllers
{
    public class ModelController : Controller 
    {
        IVoziloServis Servis = new VoziloServis();
        Mape Mapa = new Mape();
        IVoziloModel model = null;
        VoziloModelVM modelVM = null;

        // GET: Model
        public ActionResult Index()
        {
            string poruka = "Stranica koju tražite ne postoji";
            HttpStatusCode status = HttpStatusCode.NotFound;
            return new HttpStatusCodeResult(status, poruka);
        } 
        
        public ActionResult List(int? brIspisa, int? strana, string sortiraj, string naziv, int? idMarke)
        {
            IPagedList<VoziloModelVM> lstModeliVM = null;
            IPagedList<IVoziloModel> lstModeli = null;
            ViewBag.sortId = (String.IsNullOrEmpty(sortiraj)) ? "D_Id" : (sortiraj == "A_Id") ? "D_Id" : "A_Id";
            ViewBag.sortIdMarke = (sortiraj == "A_IdMarke") ? "D_IdMarke" : "A_IdMarke";
            ViewBag.sortNaziv = (sortiraj == "A_Naziv") ? "D_Naziv" : "A_Naziv";
            ViewBag.sortKratica = (sortiraj == "A_Kratica") ? "D_Kratica" : "A_Kratica";
            ISorter sorter = new Sorter(sortiraj ?? "A_Id");
            IFilter filter = new Filter(naziv, idMarke);
            INumerer stranica = new Numerer();
            stranica.Str = strana ?? 1;
            brIspisa = (brIspisa < 1) ? 10 : brIspisa;
            stranica.BrRedova = brIspisa ?? 10;
            IOdgovor<VoziloModelVM> odgovor = new Odgovor<VoziloModelVM>();

            try
            {               
                lstModeli = Servis.DohvatiModele(sorter, filter, stranica);
                lstModeliVM = new StaticPagedList<VoziloModelVM>(Mapa.maper.Map<IEnumerable<IVoziloModel>, IEnumerable<VoziloModelVM>>(lstModeli), lstModeli.GetMetaData());
                odgovor.ListaIspisa = lstModeliVM;

                ViewBag.stranica = stranica;
            }
            catch (Exception ex)
            {
                string poruka = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
                HttpStatusCode status = HttpStatusCode.InternalServerError;
                return new HttpStatusCodeResult(status, poruka);
            }
            return View(odgovor);
            
        }
        // GET: Model/Details/5
        public ActionResult Details(int idModela)
        {
            try
            {
                model = Servis.DohvatiModel(idModela);
                modelVM = Mapa.maper.Map<VoziloModelVM>(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela vozila. Opis: " + ex.Message;
            }

            return View(modelVM);
        }

        // GET: Model/Create
        public ActionResult Create()
        {            
            return View(new VoziloModelVM());
        }

        // POST: Model/Create
        [HttpPost]
        public ActionResult Create(VoziloModelVM modelVM)
        {
            try
            {                
                model = Mapa.maper.Map<VoziloModel>(modelVM);
                Servis.KreirajModel(model);
                ViewBag.Message = "Model uspješno kreiran!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa modela! Opis: " + ex.Message;    // ex.InnerException.InnerException.Message;  - jako pomoglo
            }
            return View(modelVM);
        }

        // GET: Model/Edit/5
        public ActionResult Edit(int idModela)
        {
            try
            {                
                model = Servis.DohvatiModel(idModela);
                modelVM = Mapa.maper.Map<VoziloModelVM>(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela! Opis: " + ex.Message;
            }

            return View(modelVM);
        }

        // POST: Model/Edit/5
        [HttpPost]
        public ActionResult Edit(VoziloModelVM modelVM)
        {
            try
            {
                model = Mapa.maper.Map<VoziloModel>(modelVM);
                Servis.UrediModel(model);
                ViewBag.Message = "Model uspješno uređen!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(modelVM);
        }

        // GET: Model/Delete/5
        public ActionResult Delete(int idModela)
        {
            try
            {
                model = Servis.DohvatiModel(idModela);
                modelVM = Mapa.maper.Map<VoziloModelVM>(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela! Opis: " + ex.Message;
            }
            return View(modelVM);
        }
        [HttpPost]
        public ActionResult Delete(VoziloModelVM modelVM)
        {
            try
            {
                Servis.IzbrisiModel(modelVM.Id);
                TempData["Message"] = "Model uspješno izbrisan.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja modela! Opis: " + ex.Message;
            }

            return RedirectToAction("List");
        }
    }
}