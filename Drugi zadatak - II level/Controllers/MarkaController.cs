using Drugi_zadatak___II_level.Models;
using Drugi_zadatak___II_level.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drugi_zadatak___II_level.Controllers
{
    public class MarkaController : Controller
    {
        // GET: Marka
        public ActionResult Index()
        {           
            return View("Error");        
        }

        public ActionResult List()
        {
            List<VoziloMarkaVM> lstMarke = new List<VoziloMarkaVM>();

            try
            {
                lstMarke = VoziloServis.DohvatiMarke();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa marki vozila. Opis: " + ex.Message;
            }
            return View(lstMarke);
        }

        // GET: Marka/Details/5
        public ActionResult Details(int idMarke)
        {
            VoziloMarkaVM marka = new VoziloMarkaVM();

            try
            {
                marka = VoziloServis.DohvatiMarku(idMarke);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke vozila. Opis: " + ex.Message;
            }

            return View(marka);
        }

        // GET: Marka/Create
        public ActionResult Create()
        {
            return View(new VoziloMarkaVM());
        }

        // POST: Marka/Create
        [HttpPost]
        public ActionResult Create(VoziloMarkaVM marka)
        {
            try
            {
                VoziloServis.KreirajMarku(marka);
                ViewBag.Message = "Marka je uspješno upisana!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa marke! Opis: " + ex.Message;
            }
            return View(marka);
        }

        // GET: Marka/Edit/5
        public ActionResult Edit(int idMarke)
        {
            VoziloMarkaVM marka = new VoziloMarkaVM();

            try
            {
                marka = VoziloServis.DohvatiMarku(idMarke);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }

            return View(marka);
        }

        // POST: Marka/Edit/5
        [HttpPost]
        public ActionResult Edit(VoziloMarkaVM marka)
        {
            try
            {
                VoziloServis.UrediMarku(marka);
                ViewBag.Message = "Marka uspješno uređena!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(marka);
        }

        // GET: Marka/Delete/5
        public ActionResult Delete(int idMarke)
        {
            VoziloMarkaVM marka = new VoziloMarkaVM();

            try
            {
                marka = VoziloServis.DohvatiMarku(idMarke);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(marka);
        }
        [HttpPost]
        public ActionResult Delete(VoziloMarkaVM marka)
        {
            try
            {
                VoziloServis.IzbrisiMarku(marka.Id);
                TempData["Message"] = "Marka uspješno izbrisana";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja marke! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }
    }
}