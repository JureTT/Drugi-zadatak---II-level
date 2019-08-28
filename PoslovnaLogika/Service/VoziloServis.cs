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
        public VoziloStranica DohvatiMarke(IVoziloSorter sort, IVoziloFilter filter, IVoziloStranica stranica)
        {
            VoziloStranica strIspis = (VoziloStranica)stranica;
            VoziloSorter sorter = (VoziloSorter)sort;
            sorter.Poredak = (sorter.Poredak == "A") ? "ASC" : "DESC";
           
            string upit = "SELECT* FROM VoziloMarkas ORDER BY " + sorter.Stupac + " " + sorter.Poredak + "; ";

            //List<VoziloMarka> kolekcija = _db.VoziloMarke.SqlQuery("SELECT* FROM VoziloMarkas " + sorter.Sort + "; ").ToList();

            if (!String.IsNullOrEmpty(filter.Naziv))
            {
                //kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Naziv LIKE '%" + filter.Naziv + "%' " + sorter.Sort + " ;").ToList();
                //kolekcija = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).OrderBy(x => x.GetType().ToString() == sorter.Stupac);
                strIspis.BrSvihIspisa = (from item in _db.VoziloMarke.SqlQuery(upit) where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).Count();
                strIspis.MarkaStrana = (from item in _db.VoziloMarke.SqlQuery(upit) where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
            }
            else
            {
                strIspis.BrSvihIspisa = (from item in _db.VoziloMarke.SqlQuery(upit) select item).Count();
                strIspis.MarkaStrana = (from item in _db.VoziloMarke.SqlQuery(upit) select item).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
            }

            return strIspis;
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
        public VoziloStranica DohvatiModele(IVoziloSorter sort, IVoziloFilter filter, IVoziloStranica stranica)
        {
            VoziloStranica strIspis = (VoziloStranica)stranica;
            VoziloSorter sorter = (VoziloSorter)sort;
            sorter.Poredak = (sorter.Poredak == "A") ? "ASC" : "DESC";

            string upit = "SELECT* FROM VoziloModels ORDER BY " + sorter.Stupac + " " + sorter.Poredak + "; ";

            if (!String.IsNullOrEmpty(filter.Naziv) || filter.IdMarke > 0 || filter.IdMarke != null)
            {
                if (!String.IsNullOrEmpty(filter.Naziv) && filter.IdMarke > 0 && filter.IdMarke != null)
                {
                    //kolekcija = _db.VoziloModeli.SqlQuery("SELECT * FROM VoziloModels WHERE Naziv LIKE '%" + filter.Naziv + "%' OR IdMarke = " + filter.IdMarke + " " + sorter.Sort + " ;").ToList();
                    //kolekcija = (from item in kolekcija where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) || item.IdMarke == filter.IdMarke select item).ToList();
                    strIspis.BrSvihIspisa = (from item in _db.VoziloModeli.SqlQuery(upit) where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) && item.IdMarke == filter.IdMarke select item).Count();
                    strIspis.ModelStrana = (from item in _db.VoziloModeli.SqlQuery(upit) where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) && item.IdMarke == filter.IdMarke select item).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                }
                else
                { 
                    if (!String.IsNullOrEmpty(filter.Naziv))
                    {                        
                        strIspis.BrSvihIspisa = (from item in _db.VoziloModeli.SqlQuery(upit) where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).Count();
                        strIspis.ModelStrana = (from item in _db.VoziloModeli.SqlQuery(upit) where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                    }

                    if (filter.IdMarke > 0 && filter.IdMarke != null)
                    {
                        strIspis.BrSvihIspisa = (from item in _db.VoziloModeli.SqlQuery(upit) where item.IdMarke == filter.IdMarke select item).Count();
                        strIspis.ModelStrana = (from item in _db.VoziloModeli.SqlQuery(upit) where item.IdMarke == filter.IdMarke select item).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                    }
                }
            }
            else
            {
                strIspis.BrSvihIspisa = (from item in _db.VoziloModeli.SqlQuery(upit) select item).Count();
                strIspis.ModelStrana = (from item in _db.VoziloModeli.SqlQuery(upit) select item).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
            }
                     
            return strIspis;
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
