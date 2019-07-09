using Drugi_zadatak___II_level.Models;
using Drugi_zadatak___II_level.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drugi_zadatak___II_level.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult List()
        {
            List<VoziloModelVM> lstModeli = new List<VoziloModelVM>();

            try
            {
                lstModeli = VoziloServis.DohvatiModele();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
            }
            return View(lstModeli);
        }
        [HttpPost]
        public ActionResult List(int idMarke)
        {
            List<VoziloModelVM> lstModeli = new List<VoziloModelVM>();

            try
            {
                if (idMarke == 0)
                {
                    Response.Redirect("List");
                }
                else
                {
                    lstModeli = VoziloServis.DohvatiListuModela(idMarke);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
            }
            return View(lstModeli);
        }

        // GET: Model/Details/5
        public ActionResult Details(int idModela)
        {
            VoziloModelVM model = new VoziloModelVM();

            try
            {
                model = VoziloServis.DohvatiModel(idModela);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela vozila. Opis: " + ex.Message;
            }

            return View(model);
        }

        // GET: Model/Create
        public ActionResult Create()
        {
            return View(new VoziloModelVM());
        }

        // POST: Model/Create
        [HttpPost]
        public ActionResult Create(VoziloModelVM model)
        {
            try
            {
                VoziloServis.KreirajModel(model);
                ViewBag.Message = "Model uspješno kreiran!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa modela! Opis: " + ex.Message;
            }
            return View(model);
        }

        // GET: Model/Edit/5
        public ActionResult Edit(int idModela)
        {
            VoziloModelVM model = new VoziloModelVM();

            try
            {
                model = VoziloServis.DohvatiModel(idModela);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela! Opis: " + ex.Message;
            }

            return View(model);
        }

        // POST: Model/Edit/5
        [HttpPost]
        public ActionResult Edit(VoziloModelVM model)
        {
            try
            {
                VoziloServis.UrediModel(model);
                ViewBag.Message = "Model uspješno uređen!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(model);
        }

        // GET: Model/Delete/5
        public ActionResult Delete(int idModela)
        {
            VoziloModelVM model = new VoziloModelVM();

            try
            {
                model = VoziloServis.DohvatiModel(idModela);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja modela! Opis: " + ex.Message;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(VoziloModelVM model)
        {
            try
            {
                VoziloServis.IzbrisiModel(model.Id);
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