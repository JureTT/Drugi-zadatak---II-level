using AutoMapper;
using Drugi_zadatak___II_level.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Drugi_zadatak___II_level.Service
{
    public class VoziloServis
    {
        /////// --- AUTOMAPER --- //////
        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<VoziloMarka, VoziloMarkaVM>();
            cfg.CreateMap<VoziloModel, VoziloModelVM>();
            cfg.CreateMap<VoziloMarkaVM, VoziloMarka>();
            cfg.CreateMap<VoziloModelVM, VoziloModel>();
        });
        IMapper maper => configuration.CreateMapper();
                        
        public static VozilaDbContext _db = new VozilaDbContext();

        static VoziloServis servis = new VoziloServis();

        #region MarkaCRUD
        public List<VoziloMarkaVM> DohvatiMarkeVM()
        {
            List<VoziloMarka> kolekcija = (from item in _db.VoziloMarke select item).ToList();
            List<VoziloMarkaVM> kolekcijaVM = maper.Map<List<VoziloMarkaVM>>(kolekcija);
            return kolekcijaVM;
        }
        public static List<VoziloMarkaVM> DohvatiMarke()
        {
            return servis.DohvatiMarkeVM();
        }

        public VoziloMarkaVM DohvatiMarkuVM(int idMarka)
        {
            VoziloMarka marka = _db.VoziloMarke.Find(idMarka);
            VoziloMarkaVM markaVM = maper.Map<VoziloMarkaVM>(marka);
            return markaVM;
        }
        public static VoziloMarkaVM DohvatiMarku(int idMarka)
        {
            return servis.DohvatiMarkuVM(idMarka);
        }

        public void UrediMarkuVM(VoziloMarkaVM marka)
        {
            VoziloMarka novo = maper.Map<VoziloMarka>(marka);
            VoziloMarka orginal = _db.VoziloMarke.Find(novo.Id);         
            _db.Entry(orginal).CurrentValues.SetValues(novo);
            _db.SaveChanges();         
        }
        public static void UrediMarku(VoziloMarkaVM marka)
        {
            servis.UrediMarkuVM(marka);
        }

        public object KreirajMarkuVM(VoziloMarkaVM marka)
        {
            VoziloMarka orginal = maper.Map<VoziloMarka>(marka);
            _db.VoziloMarke.Add(orginal);
            _db.SaveChanges();
            
            return marka;
        }
        public static object KreirajMarku(VoziloMarkaVM marka)
        {
            return servis.KreirajMarkuVM(marka);
        }

        public static void IzbrisiMarku(int idMarke)
        {
            VoziloMarka marka = _db.VoziloMarke.Find(idMarke);
            _db.VoziloMarke.Remove(marka);
            _db.SaveChanges();
            
        }

        #endregion

        #region ModelCRUD
        public List<VoziloModelVM> DohvatiModeleVM()
        {
            List<VoziloModel> kolekcija = (from item in _db.VoziloModeli select item).ToList();
            List<VoziloModelVM> kolekcijaVM = maper.Map<List<VoziloModelVM>>(kolekcija);
            return kolekcijaVM;
        }
        public static List<VoziloModelVM> DohvatiModele()
        {
            return servis.DohvatiModeleVM();
        }
        public List<VoziloModelVM> DohvatiListuModelaVM(int idMarke)
        {
            List<VoziloModel> kolekcija = (from item in _db.VoziloModeli where item.IdMarke == idMarke select item).ToList();
            List<VoziloModelVM> kolekcijaVM = maper.Map<List<VoziloModelVM>>(kolekcija);
            return kolekcijaVM;
        }
        public static List<VoziloModelVM> DohvatiListuModela(int idMarke)
        {
            return servis.DohvatiListuModelaVM(idMarke);
        }

        public VoziloModelVM DohvatiModelVM(int idModela)
        {
            VoziloModel model = _db.VoziloModeli.Find(idModela);
            VoziloModelVM modelVM = maper.Map<VoziloModelVM>(model);
            return modelVM;
        }
        public static VoziloModelVM DohvatiModel(int idModela)
        {
            return servis.DohvatiModelVM(idModela);
        }

        public void UrediModelVM(VoziloModelVM model)
        {
            VoziloModel novo = maper.Map<VoziloModel>(model);
            VoziloModel orginal = _db.VoziloModeli.Find(novo.Id);
            _db.Entry(orginal).CurrentValues.SetValues(novo);
            _db.SaveChanges();
        }
        public static void UrediModel(VoziloModelVM model)
        {
            servis.UrediModelVM(model);
        }

        public object KreirajModelVM(VoziloModelVM model)
        {
            VoziloModel orginal = maper.Map<VoziloModel>(model);
            _db.VoziloModeli.Add(orginal);
            _db.SaveChanges();
            return model;
        }
        public static object KreirajModel(VoziloModelVM model)
        {
            return servis.KreirajModelVM(model);
        }

        public static void IzbrisiModel(int idModela)
        {
            VoziloModel model = _db.VoziloModeli.Find(idModela);
            _db.VoziloModeli.Remove(model);
            _db.SaveChanges();
        }
        #endregion
    }
}