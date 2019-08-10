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

        // GET: Model
        public ActionResult Index()
        {
            return View("Error");
        }        
        public ActionResult List(int? idMarke,int? strana, string sortiraj, string naziv)
        {            
            List<VoziloModelVM> lstModeliVM = null;
            IPagedList<VoziloModelVM> listaModeliVM = null;
            ViewBag.sortId = "A_Id";
            ViewBag.sortIdMarke = "A_IdMarke";
            ViewBag.sortNaziv = "A_Naziv";
            ViewBag.sortKratica = "A_Kratica";
            int str;
            if (strana == null)
            {
                str = 1;
            }
            else
            {
                str = strana.Value;
            }
            try
            {
                List<VoziloModel> lstModeli;
                if (idMarke > 0)
                {
                    lstModeli = Servis.DohvatiListuModela(idMarke);                    
                }
                else
                {
                    lstModeli = Servis.DohvatiModele();
                }
                if (naziv != null)
                {
                    lstModeli = (from item in lstModeli where item.Naziv.ToLower().Contains(naziv.ToLower()) select item).ToList();
                }

                switch (sortiraj)
                {
                    case "D_Id":
                        lstModeli = lstModeli.OrderByDescending(x => x.Id).ToList();
                        ViewBag.sortId = "A_Id";
                        break;
                    case "A_IdMarke":
                        lstModeli = lstModeli.OrderBy(x => x.IdMarke).ToList();
                        ViewBag.sortIdMarke = "D_IdMarke";
                        break;
                    case "D_IdMarke":
                        lstModeli = lstModeli.OrderByDescending(x => x.IdMarke).ToList();
                        ViewBag.sortIdMarke = "A_IdMarke";
                        break;
                    case "A_Naziv":
                        lstModeli = lstModeli.OrderBy(x => x.Naziv).ToList();
                        ViewBag.sortNaziv = "D_Naziv";
                        break;
                    case "D_Naziv":
                        lstModeli = lstModeli.OrderByDescending(x => x.Naziv).ToList();
                        ViewBag.sortNaziv = "A_Naziv";
                        break;
                    case "A_Kratica":
                        lstModeli = lstModeli.OrderBy(x => x.Kratica).ToList();
                        ViewBag.sortKratica = "D_Kratica";
                        break;
                    case "D_Kratica":
                        lstModeli = lstModeli.OrderByDescending(x => x.Kratica).ToList();
                        ViewBag.sortKratica = "A_Kratica";
                        break;
                    default:
                        ViewBag.sortId = "D_Id"; 
                        break;
                 }                
                lstModeliVM = Mapa.maper.Map<List<VoziloModelVM>>(lstModeli);
                listaModeliVM = lstModeliVM.ToPagedList(str, 10);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa modela vozila. Opis: " + ex.Message;
            }
            return View(listaModeliVM);
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