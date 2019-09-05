using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;
using System.Linq.Expressions;

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
        public (List<VoziloMarka>, int) DohvatiMarke(IVoziloSorter sort, IFilter filter, IStranica stranica)
        {
            Stranica strIspis = (Stranica)stranica;
            VoziloSorter sorter = (VoziloSorter)sort;
            IEnumerable<VoziloMarka> upit = null;
            List<VoziloMarka> listaIspisa = null;
            //sorter.Poredak = (sorter.Poredak == "A") ? "ASC" : "DESC";

            var parametar = Expression.Parameter(typeof(VoziloMarka), "item");      //  -- kreiranje parametra
            var izraz = Expression.Property(parametar, sorter.Stupac);
            var konverzija = Expression.Convert(izraz, typeof(object));
            var lambda = Expression.Lambda<Func<VoziloMarka, object>>(konverzija, parametar);

            //string upit = "SELECT * FROM VoziloMarkas" ORDER BY " + sorter.Stupac + " " + sorter.Poredak + "; ";
            //List<VoziloMarka> kolekcija = _db.VoziloMarke.SqlQuery("SELECT* FROM VoziloMarkas " + sorter.Sort + "; ").ToList();

            if (!String.IsNullOrEmpty(filter.PretragaUpita))
            {
                //kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Naziv LIKE '%" + filter.Naziv + "%' " + sorter.Sort + " ;").ToList();
                //kolekcija = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).OrderBy(x => x.GetType().ToString() == sorter.Stupac);
                upit = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) select item);
                strIspis.BrSvihIspisa = upit.Count();
                if (sorter.Poredak == "A")
                {
                    listaIspisa = upit.OrderBy(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                }
                else
                {
                    listaIspisa = upit.OrderByDescending(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                }
            }
            else
            {
                upit = (from item in _db.VoziloMarke select item);
                strIspis.BrSvihIspisa = upit.Count();
                if (sorter.Poredak == "A")
                {
                    listaIspisa = upit.OrderBy(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                }
                else
                {
                    listaIspisa = upit.OrderByDescending(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                }
            }

            return (listaIspisa, strIspis.BrSvihIspisa);
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
        public (List<VoziloModel>, int) DohvatiModele(IVoziloSorter sort, IFilter filter, IStranica stranica)
        {
            Stranica strIspis = (Stranica)stranica;
            VoziloSorter sorter = (VoziloSorter)sort;
            IEnumerable<VoziloModel> upit = null;
            List<VoziloModel> listaIspisa = null;

            var parametar = Expression.Parameter(typeof(VoziloModel), "item");
            var izraz = Expression.Property(parametar, sorter.Stupac);
            var konverzija = Expression.Convert(izraz, typeof(object));
            var lambda = Expression.Lambda<Func<VoziloModel, object>>(konverzija, parametar);

            if (!String.IsNullOrEmpty(filter.PretragaUpita) || filter.IdMarke > 0 || filter.IdMarke != null)
            {
                if (!String.IsNullOrEmpty(filter.PretragaUpita) && filter.IdMarke > 0 && filter.IdMarke != null)
                {
                    upit = (from item in _db.VoziloModeli where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) && item.IdMarke == filter.IdMarke select item);
                    strIspis.BrSvihIspisa = upit.Count();
                    if (sorter.Poredak == "A")
                    {
                        listaIspisa = upit.OrderBy(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                    }
                    else
                    {
                        listaIspisa = upit.OrderByDescending(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                    }
                }
                else
                { 
                    if (!String.IsNullOrEmpty(filter.PretragaUpita))
                    {
                        upit = (from item in _db.VoziloModeli where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) select item);
                        strIspis.BrSvihIspisa = upit.Count();
                        if (sorter.Poredak == "A")
                        {
                            listaIspisa = upit.OrderBy(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                        }
                        else
                        {
                            listaIspisa = upit.OrderByDescending(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                        }
                    }

                    if (filter.IdMarke > 0 && filter.IdMarke != null)
                    {
                        upit = (from item in _db.VoziloModeli where item.IdMarke == filter.IdMarke select item);
                        strIspis.BrSvihIspisa = upit.Count();
                        if (sorter.Poredak == "A")
                        {
                            listaIspisa = upit.OrderBy(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                        }
                        else
                        {
                            listaIspisa = upit.OrderByDescending(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                        }
                    }
                }
            }
            else
            {
                upit = (from item in _db.VoziloModeli select item);
                strIspis.BrSvihIspisa = upit.Count();
                if (sorter.Poredak == "A")
                {
                    listaIspisa = upit.OrderBy(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                }
                else
                {
                    listaIspisa = upit.OrderByDescending(lambda.Compile()).Skip((strIspis.Strana - 1) * strIspis.BrIspisa).Take(strIspis.BrIspisa).ToList();
                }
            }
                     
            return (listaIspisa ,strIspis.BrSvihIspisa);
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
