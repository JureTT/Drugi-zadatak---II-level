using PoslovnaLogika.Models;
using PoslovnaLogika.Service;
using Drugi_zadatak___II_level.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Filter = PoslovnaLogika.Models.Filter;

namespace Drugi_zadatak___II_level.Controllers
{
    public class MarkaController : Controller
    {        
        VoziloServis Servis = new VoziloServis();
        Mape Mapa = new Mape();
        VoziloMarka marka = null;
        VoziloMarkaVM markaVM = null;

        // GET: Marka
        public ActionResult Index()
        {           
            return View("Error");        
        }

        public ActionResult List(int? brIspisa, int? strana, string sortiraj, string naziv)
        {           
            //IPagedList<VoziloMarkaVM> lstMarkePG = null;
            List<VoziloMarkaVM> lstMarkeVM = null;
            IPagedList<IVoziloMarka> lstMarke = null;
            ViewBag.sortId = (String.IsNullOrEmpty(sortiraj))? "D_Id" : (sortiraj == "A_Id") ? "D_Id": "A_Id";
            ViewBag.sortNaziv = (sortiraj == "A_Naziv") ? "D_Naziv" : "A_Naziv";
            ViewBag.sortKratica = (sortiraj == "A_Kratica") ? "D_Kratica" : "A_Kratica";
            Sorter sorter = new Sorter(sortiraj ?? "A_Id");
            Filter filter = new Filter(naziv);            
            Numerer stranica = new Numerer();
            stranica.UnesiBrStr(strana ?? 1);
            stranica.UnesiBrRedova(brIspisa);

            try
            {
                if (naziv != null || sortiraj != null || strana != null)
                {
                    lstMarke = Servis.DohvatiMarke(sorter, filter, stranica);
                    //lstMarke = stranica.ListaIspisa;
                    lstMarkeVM = Mapa.maper.Map<List<VoziloMarkaVM>>(lstMarke);
                }
                else
                {
                    lstMarke = Servis.DohvatiMarke().ToPagedList<IVoziloMarka>(stranica.Str,stranica.BrRedova);
                    stranica.BrSvihRedova = lstMarke.Count();
                    //lstMarke = lstMarke.Skip((stranica.Str - 1) * stranica.BrRedova).Take(stranica.BrRedova).ToList();
                    lstMarkeVM = Mapa.maper.Map<List<VoziloMarkaVM>>(lstMarke);
                }
                
                //lstMarkePG = lstMarkeVM.ToPagedList(stranica.Strana, stranica.BrIspisa);                
                ViewBag.stranica = stranica;
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
            try
            {
                marka = Servis.DohvatiMarku(idMarke);
                markaVM = Mapa.maper.Map<VoziloMarkaVM>(marka);                
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke vozila. Opis: " + ex.Message;
            }
            return View(markaVM);
        }

        // GET: Marka/Create
        public ActionResult Create()
        {
            return View(new VoziloMarkaVM());
        }

        // POST: Marka/Create
        [HttpPost]
        public ActionResult Create(IVoziloMarkaVM markaVM)
        {
            try
            {
                marka = Mapa.maper.Map<VoziloMarka>(markaVM);
                Servis.KreirajMarku(marka);
                ViewBag.Message = "Marka je uspješno upisana!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa marke! Opis: " + ex.Message;
            }
            return View(markaVM);
        }

        // GET: Marka/Edit/5
        public ActionResult Edit(int idMarke)
        {
            try
            {
                marka = Servis.DohvatiMarku(idMarke);
                markaVM = Mapa.maper.Map<VoziloMarkaVM>(marka);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }

            return View(markaVM);
        }

        // POST: Marka/Edit/5
        [HttpPost]
        public ActionResult Edit(IVoziloMarkaVM markaVM)
        {
            try
            {
                marka = Mapa.maper.Map<VoziloMarka>(markaVM);
                Servis.UrediMarku(marka);
                ViewBag.Message = "Marka uspješno uređena!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(markaVM);
        }

        // GET: Marka/Delete/5
        public ActionResult Delete(int idMarke)
        {
            try
            {
                marka = Servis.DohvatiMarku(idMarke);
                markaVM = Mapa.maper.Map<VoziloMarkaVM>(marka);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja marke! Opis: " + ex.Message;
            }
            return View(markaVM);
        }
        [HttpPost]
        public ActionResult Delete(IVoziloMarkaVM markaVM)
        {
            try
            {
                Servis.IzbrisiMarku(markaVM.Id);
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