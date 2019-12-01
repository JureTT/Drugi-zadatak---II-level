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
using System.Net;

namespace Drugi_zadatak___II_level.Controllers
{
    public class MarkaController : Controller
    {        
        IVoziloServis Servis = new VoziloServis();
        Mape Mapa = new Mape();
        IVoziloMarka marka = null;
        VoziloMarkaVM markaVM = null;

        // GET: Marka
        public ActionResult Index()
        {
            string poruka = "Stranica koju tražite ne postoji";
            HttpStatusCode status = HttpStatusCode.NotFound;
            return new HttpStatusCodeResult(status, poruka);        
        }

        public ActionResult List(int? brIspisa, int? strana, string sortiraj, string naziv)
        {           
            IPagedList<VoziloMarkaVM> lstMarkeVM = null;
            IPagedList<IVoziloMarka> lstMarke = null;
            ViewBag.sortId = (String.IsNullOrEmpty(sortiraj))? "D_Id" : (sortiraj == "A_Id") ? "D_Id": "A_Id";
            ViewBag.sortNaziv = (sortiraj == "A_Naziv") ? "D_Naziv" : "A_Naziv";
            ViewBag.sortKratica = (sortiraj == "A_Kratica") ? "D_Kratica" : "A_Kratica";
            ISorter sorter = new Sorter(sortiraj ?? "A_Id");
            IFilter filter = new Filter(naziv);            
            INumerer stranica = new Numerer();
            stranica.Str = strana ?? 1;
            brIspisa = (brIspisa < 1) ? 10 : brIspisa;
            stranica.BrRedova = brIspisa ?? 10;
            IOdgovor<VoziloMarkaVM> odgovor = new Odgovor<VoziloMarkaVM>();

            try
            {
                lstMarke = Servis.DohvatiMarke(sorter, filter, stranica);
                lstMarkeVM = new StaticPagedList<VoziloMarkaVM>(Mapa.maper.Map<IEnumerable<IVoziloMarka>, IEnumerable<VoziloMarkaVM>>(lstMarke), lstMarke.GetMetaData());
                odgovor.ListaIspisa = lstMarkeVM;

                ViewBag.stranica = stranica;
            }
            catch (Exception ex)
            {
                string poruka = "Greška kod dohvaćanja popisa marki vozila. Opis: " + ex.Message;
                HttpStatusCode status = HttpStatusCode.InternalServerError;
                return new HttpStatusCodeResult(status, poruka);
            }
            return View(odgovor);
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
        public ActionResult Create(VoziloMarkaVM markaVM)
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
        public ActionResult Edit(VoziloMarkaVM markaVM)
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
        public ActionResult Delete(VoziloMarkaVM markaVM)
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