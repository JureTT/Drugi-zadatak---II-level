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

namespace Drugi_zadatak___II_level.Controllers
{
    public class ModelController : Controller
    {
        VoziloServis Servis = new VoziloServis();
        Mape Mapa = new Mape();
        VoziloModel model = null;
        VoziloModelVM modelVM = null;

        // GET: Model
        public ActionResult Index()
        {
            return View("Error");
        }        
        public ActionResult List(int? idMarke,int? strana, string sortiraj, string naziv)
        {
            IPagedList<VoziloModelVM> lstModeliPG = null;
            List<VoziloModelVM> lstModeliVM = null;
            List<VoziloModel> lstModeli = null;
            ViewBag.sortId = (sortiraj == "A_Id")? "D_Id": "A_Id";
            ViewBag.sortIdMarke = (sortiraj == "A_IdMarke") ? "D_IdMarke" : "A_IdMarke";
            ViewBag.sortNaziv = (sortiraj == "A_Naziv") ? "D_Naziv" : "A_Naziv";
            ViewBag.sortKratica = (sortiraj == "A_Kratica") ? "D_Kratica" : "A_Kratica";
            Sortiranje sorter = new Sortiranje();
            sorter.OdrediSortiranje(sortiraj);
            Filteri filter = new Filteri();
            filter.UnesiFiltere(naziv, idMarke);
            Stranice stranica = new Stranice();
            stranica.UnesiStranice(strana); 

            try
            {
                if (naziv != null || idMarke != null || sortiraj != null || strana != null)
                {
                    lstModeli = Servis.DohvatiModele(sorter, filter, stranica);
                }
                else
                {
                    lstModeli = Servis.DohvatiModele();
                }
                lstModeliVM = Mapa.maper.Map<List<VoziloModelVM>>(lstModeli);
                lstModeliPG = lstModeliVM.ToPagedList(stranica.Strana, stranica.BrIspisa);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa marki vozila. Opis: " + ex.Message;
            }
            return View(lstModeliPG);
            
                //if (idMarke > 0)
                //{
                //    lstModeli = Servis.DohvatiListuModela(idMarke);                    
                //}
                //else
                //{
                //    lstModeli = Servis.DohvatiModele();
                //}
                //if (naziv != null)
                //{
                //    lstModeli = (from item in lstModeli where item.Naziv.ToLower().Contains(naziv.ToLower()) select item).ToList();
                //}
        }
        //[HttpPost]//ovo ti najvjerovatnije ne treba
        //public ActionResult List(int idMarke,int? strana)
        //{
        //    List<VoziloModelVM> lstModeliVM = new List<VoziloModelVM>();
        //    IPagedList<VoziloModelVM> listaModeliVM = null;
        //    int str;
        //    if (strana == null)
        //    {
        //        str = 1;
        //    }
        //    else
        //    {
        //        str = strana.Value;
        //    }
        //    try
        //    {
        //        if (idMarke == 0)
        //        {
        //            Response.Redirect("List");
        //        }
        //        else
        //        {
        //            List<VoziloModel> lstModeli = Servis.DohvatiListuModela(idMarke);
        //            lstModeliVM = Mapa.maper.Map<List<VoziloModelVM>>(lstModeli);
        //            listaModeliVM = lstModeliVM.ToPagedList(str, 10); 
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
        //    }
        //    return View(listaModeliVM);
        //}

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
                ViewBag.Message = "Greška kod upisa modela! Opis: " + ex.Message;
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