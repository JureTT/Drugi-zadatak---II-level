using Drugi_zadatak___II_level.Models;
using PoslovnaLogika.Models;
using PoslovnaLogika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drugi_zadatak___II_level.Controllers
{
    public class ModelController : Controller
    {
        VoziloServis Servis = new VoziloServis();
        Mape Mapa = new Mape();

        // GET: Model
        public ActionResult Index()
        {
            return View("Error");
        }
        public void metoda()
        {

        }
        public ActionResult List()
        {
            List<VoziloModelVM> lstModeliVM = new List<VoziloModelVM>();

            try
            {
                List<VoziloModel> lstModeli = Servis.DohvatiModele();
                lstModeliVM = Mapa.maper.Map<List<VoziloModelVM>>(lstModeli);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
            }
            return View(lstModeliVM);
        }
        [HttpPost]
        public ActionResult List(int idMarke)
        {
            List<VoziloModelVM> lstModeliVM = new List<VoziloModelVM>();

            try
            {
                if (idMarke == 0)
                {
                    Response.Redirect("List");
                }
                else
                {
                    List<VoziloModel> lstModeli = Servis.DohvatiListuModela(idMarke);
                    lstModeliVM = Mapa.maper.Map<List<VoziloModelVM>>(lstModeli);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
            }
            return View(lstModeliVM);
        }

        // GET: Model/Details/5
        public ActionResult Details(int idModela)
        {
            VoziloModelVM modelVM = new VoziloModelVM();

            try
            {
                VoziloModel model = Servis.DohvatiModel(idModela);
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
                VoziloModel model = Mapa.maper.Map<VoziloModel>(modelVM);
                Servis.KreirajModel(model);
                ViewBag.Message = "Model uspješno kreiran!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa modela! Opis: " + ex.Message;
            }
            return View(modelVM);
        }

        // GET: Model/Edit/5
        public ActionResult Edit(int idModela)
        {
            VoziloModelVM modelVM = new VoziloModelVM();

            try
            {                
                VoziloModel model = Servis.DohvatiModel(idModela);
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
                VoziloModel model = Mapa.maper.Map<VoziloModel>(modelVM);
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
            VoziloModelVM modelVM = new VoziloModelVM();

            try
            {
                VoziloModel model = Servis.DohvatiModel(idModela);
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