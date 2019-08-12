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

        public ActionResult List(int? strana, string sortiraj, string naziv, string kratica)
        {
            List<VoziloMarkaVM> lstMarkeVM = null;
            IPagedList<VoziloMarkaVM> listaMarkeVM = null;
            ViewBag.sortId = "A_Id";
            ViewBag.sortNaziv = "A_Naziv";
            ViewBag.sortKratica = "A_Kratica";
            int str = (strana == null)? str = 1 : str = strana.Value;

            try
            {
                List<VoziloMarka> lstMarke = Servis.DohvatiMarke();
                                                  
                if (naziv != "" && kratica != "" && naziv != null && kratica != null)
                {                        
                    lstMarke = (from item in lstMarke where item.Naziv.ToLower().Contains(naziv.ToLower()) || item.Kratica.ToLower().Contains(kratica.ToLower()) select item).ToList();                        
                }
                else
                {
                    if (naziv != "" && naziv != null)
                    {
                        lstMarke = (from item in lstMarke where item.Naziv.ToLower().Contains(naziv.ToLower()) select item).ToList();                            
                    }
                    if (kratica != "" && kratica != null)
                    {
                        lstMarke = (from item in lstMarke where item.Kratica.ToLower().Contains(kratica.ToLower()) select item).ToList();
                    }
                }

                switch (sortiraj)
                {
                    case "D_Id":
                        lstMarke = lstMarke.OrderByDescending(x => x.Id).ToList();
                        ViewBag.sortId = "A_Id";
                        break;
                    case "A_Naziv":
                        lstMarke = lstMarke.OrderBy(x => x.Naziv).ToList();
                        ViewBag.sortNaziv = "D_Naziv";
                        break;
                    case "D_Naziv":
                        lstMarke = lstMarke.OrderByDescending(x => x.Naziv).ToList();
                        ViewBag.sortNaziv = "A_Naziv";
                        break;
                    case "A_Kratica":
                        lstMarke = lstMarke.OrderBy(x => x.Kratica).ToList();
                        ViewBag.sortKratica = "D_Kratica";
                        break;
                    case "D_Kratica":
                        lstMarke = lstMarke.OrderByDescending(x => x.Kratica).ToList();
                        ViewBag.sortKratica = "A_Kratica";
                        break;
                    default:
                        ViewBag.sortId = "D_Id";
                        break;
                }
                lstMarkeVM = Mapa.maper.Map<List<VoziloMarkaVM>>(lstMarke);
                listaMarkeVM = lstMarkeVM.ToPagedList(str, 10);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa marki vozila. Opis: " + ex.Message;
            }
            return View(listaMarkeVM);
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