using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace PoslovnaLogika.Service
{
    public class VoziloServis : IVoziloServis
    {
        public VozilaDbContext _db = new VozilaDbContext();

        #region MarkaCRUD
        public List<VoziloMarka> DohvatiMarke()
        {
            List<VoziloMarka> kolekcija = (from item in _db.VoziloMarke select item).ToList();
            return kolekcija;
        }
        public List<VoziloMarka> DohvatiMarke(ISortiranje sorter, IFilteri filter, IStranice stranica)
        {
            List <VoziloMarka> kolekcija = _db.VoziloMarke.SqlQuery("SELECT* FROM VoziloMarkas " + sorter.Sort + "; ").ToList();

            if (filter.Naziv != "" && filter.Kratica != "" && filter.Naziv != null && filter.Kratica != null)
            {
                kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Naziv LIKE '%" + filter.Naziv + "%' OR Kratica LIKE '%" + filter.Kratica + "%' " + sorter.Sort + " ;").ToList();
                //kolekcija = (from item in kolekcija where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) || item.Kratica.ToLower().Contains(filter.Kratica.ToLower()) select item).ToList();
            }
            else
            {
                if (filter.Naziv != "" && filter.Naziv != null)
                {
                    kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Naziv LIKE '%" + filter.Naziv + "%' " + sorter.Sort + " ;").ToList();
                    //kolekcija = (from item in kolekcija where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).ToList();
                }
                if (filter.Kratica != "" && filter.Kratica != null)
                {
                    kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Kratica LIKE '%" + filter.Kratica + "%' " + sorter.Sort + " ;").ToList();
                    //kolekcija = (from item in kolekcija where item.Kratica.ToLower().Contains(filter.Kratica.ToLower()) select item).ToList();
                }
            }
            return kolekcija;
        }
        //public List<VoziloMarka> DohvatiListuMarki(int? idMarke)
        //{
        //    List<VoziloMarka> kolekcija = (from item in _db.VoziloMarke where item.Id == idMarke select item).ToList();
        //    return kolekcija;
        //}

        public VoziloMarka DohvatiMarku(int idMarka)
        {
            VoziloMarka marka = _db.VoziloMarke.Find(idMarka);
            return marka;
        }
        
        public void KreirajMarku(IVoziloMarka marka)
        {
            VoziloMarka novo = (VoziloMarka)marka;
            _db.VoziloMarke.Add(novo);
            _db.SaveChanges();
        }

        public void UrediMarku(IVoziloMarka marka)
        {            
            VoziloMarka orginal = _db.VoziloMarke.Find(marka.Id);
            _db.Entry(orginal).CurrentValues.SetValues(marka);
            _db.SaveChanges();
        }

        public void IzbrisiMarku(int idMarke)
        {
            VoziloMarka marka = _db.VoziloMarke.Find(idMarke);
            _db.VoziloMarke.Remove(marka);
            _db.SaveChanges();
        }

        #endregion

        #region ModelCRUD
        public List<VoziloModel> DohvatiModele()
        {
            List<VoziloModel> kolekcija = (from item in _db.VoziloModeli select item).ToList();
            return kolekcija;
        }
        public List<VoziloModel> DohvatiModele(ISortiranje sorter, IFilteri filteri, IStranice stranica)
        {
            List<VoziloModel> kolekcija = _db.VoziloModeli.SqlQuery("SELECT* FROM VoziloModels " + sorter.Sort + "; ").ToList();
            Filteri filter = (Filteri)filteri;

            if (filter.Naziv != "" && filter.IdMarke >= 0 && filter.Naziv != null && filter.IdMarke != null)
            {
                kolekcija = _db.VoziloModeli.SqlQuery("SELECT * FROM VoziloModels WHERE Naziv LIKE '%" + filter.Naziv + "%' OR IdMarke = " + filter.IdMarke + " " + sorter.Sort + " ;").ToList();
                //kolekcija = (from item in kolekcija where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) || item.IdMarke == filter.IdMarke select item).ToList();
            }
            else
            {
                if (filter.Naziv != "" && filter.Naziv != null)
                {
                    kolekcija = _db.VoziloModeli.SqlQuery("SELECT * FROM VoziloModels WHERE Naziv LIKE '%" + filter.Naziv + "%' " + sorter.Sort + " ;").ToList();
                    //kolekcija = (from item in kolekcija where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).ToList();
                }
                if (filter.IdMarke > 0 && filter.IdMarke != null)
                {
                    kolekcija = _db.VoziloModeli.SqlQuery("SELECT * FROM VoziloModels WHERE IdMarke = " + filter.IdMarke + " " + sorter.Sort + " ;").ToList();
                    //kolekcija = (from item in kolekcija where item.IdMarke == filter.IdMarke select item).ToList();
                }
            }
            return kolekcija;
        }
        //// -- izgleda da je ova metoda nepotrebna uz nove promjene
        //public List<VoziloModel> DohvatiListuModela(int? idMarke)
        //{
        //    List<VoziloModel> kolekcija = (from item in _db.VoziloModeli where item.IdMarke == idMarke select item).ToList();
        //    return kolekcija;
        //}

        public VoziloModel DohvatiModel(int idModela)
        {
            VoziloModel model = _db.VoziloModeli.Find(idModela);
            return model;
        }

        public object KreirajModel(IVoziloModel model)
        {
            VoziloModel novo = (VoziloModel)model;
            _db.VoziloModeli.Add(novo);
            _db.SaveChanges();
            return model;
        }

        public void UrediModel(IVoziloModel model)
        {
            VoziloModel orginal = _db.VoziloModeli.Find(model.Id);
            _db.Entry(orginal).CurrentValues.SetValues(model);
            _db.SaveChanges();
        }

        public void IzbrisiModel(int idModela)
        {
            VoziloModel model = _db.VoziloModeli.Find(idModela);
            _db.VoziloModeli.Remove(model);
            _db.SaveChanges();
        }
        #endregion
    }
}
