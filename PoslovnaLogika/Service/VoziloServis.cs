using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        public (List<VoziloMarka>, int) DohvatiMarke(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IQueryable<VoziloMarka> upit = null;
            List<VoziloMarka> listaIspisa = null;
            //sorter.Poredak = (sorter.Poredak == "A") ? "ASC" : "DESC";
            sorter.Poredak = (sorter.Poredak == "A") ? "OrderBy" : "OrderByDescending";

            var parametar = Expression.Parameter(typeof(VoziloMarka), "item");      //  -- kreiranje parametra
            var izraz = Expression.Property(parametar, sorter.Stupac);
            //var konverzija = Expression.Convert(izraz, typeof(object));
            //var lambda = Expression.Lambda<Func<VoziloMarka, object>>(konverzija, parametar);
            var lambda = Expression.Lambda(izraz, parametar);
            MethodCallExpression ispis = null;
            //PropertyInfo svojstvo = typeof(VoziloMarka).GetProperty(sorter.Stupac);

            //string upit = "SELECT * FROM VoziloMarkas" ORDER BY " + sorter.Stupac + " " + sorter.Poredak + "; ";
            //List<VoziloMarka> kolekcija = _db.VoziloMarke.SqlQuery("SELECT* FROM VoziloMarkas " + sorter.Sort + "; ").ToList();

            if (!String.IsNullOrEmpty(filter.PretragaUpita))
            {
                //kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Naziv LIKE '%" + filter.Naziv + "%' " + sorter.Sort + " ;").ToList();
                //kolekcija = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).OrderBy(x => x.GetType().ToString() == sorter.Stupac);
                upit = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) select item);
                strIspis.BrSvihRedova = upit.Count();
                ispis = Expression.Call(
                typeof(Queryable),
                sorter.Poredak,
                new[] { typeof(VoziloMarka), izraz.Type },
                upit.Expression,
                Expression.Quote(lambda));

                listaIspisa = upit.Provider.CreateQuery<VoziloMarka>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                //listaIspisa = upit.OrderBy(sorter.Stupac + " " + sorter.Poredak).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                //OrderBy(lambda,Compile())
                //OrderBy(item => svojstvo.GetValue(item))
                //OrderBy(item => item.GetType().GetProperty(property).GetValue(item))
            }
            else
            {
                upit = (from item in _db.VoziloMarke select item);
                strIspis.BrSvihRedova = upit.Count();
                ispis = Expression.Call(typeof(Queryable), sorter.Poredak, new[] { typeof(VoziloMarka), izraz.Type }, upit.Expression, Expression.Quote(lambda));

                listaIspisa = upit.Provider.CreateQuery<VoziloMarka>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                //listaIspisa = upit.OrderBy(sorter.Stupac + " " + sorter.Poredak).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
            }

            return (listaIspisa, strIspis.BrSvihRedova);
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
        public (List<VoziloModel>, int) DohvatiModele(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IQueryable<VoziloModel> upit = null;
            List<VoziloModel> listaIspisa = null;
            sorter.Poredak = (sorter.Poredak == "A") ? "OrderBy" : "OrderByDescending";

            var parametar = Expression.Parameter(typeof(VoziloModel), "item");
            var izraz = Expression.Property(parametar, sorter.Stupac);
            var lambda = Expression.Lambda(izraz, parametar);
            MethodCallExpression ispis = null;

            if (!String.IsNullOrEmpty(filter.PretragaUpita) || filter.IdMarke > 0 || filter.IdMarke != null)
            {
                if (!String.IsNullOrEmpty(filter.PretragaUpita) && filter.IdMarke > 0 && filter.IdMarke != null)
                {
                    upit = (from item in _db.VoziloModeli where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) && item.IdMarke == filter.IdMarke select item);
                    strIspis.BrSvihRedova = upit.Count();
                    ispis = Expression.Call(typeof(Queryable), sorter.Poredak, new[] { typeof(VoziloModel), izraz.Type }, upit.Expression, Expression.Quote(lambda));
                    listaIspisa = upit.Provider.CreateQuery<VoziloModel>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                }
                else
                { 
                    if (!String.IsNullOrEmpty(filter.PretragaUpita))
                    {
                        upit = (from item in _db.VoziloModeli where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) select item);
                        strIspis.BrSvihRedova = upit.Count();
                        ispis = Expression.Call(typeof(Queryable), sorter.Poredak, new[] { typeof(VoziloModel), izraz.Type }, upit.Expression, Expression.Quote(lambda));
                        listaIspisa = upit.Provider.CreateQuery<VoziloModel>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                    }

                    if (filter.IdMarke > 0 && filter.IdMarke != null)
                    {
                        upit = (from item in _db.VoziloModeli where item.IdMarke == filter.IdMarke select item);
                        strIspis.BrSvihRedova = upit.Count();
                        ispis = Expression.Call(typeof(Queryable), sorter.Poredak, new[] { typeof(VoziloModel), izraz.Type }, upit.Expression, Expression.Quote(lambda));
                        listaIspisa = upit.Provider.CreateQuery<VoziloModel>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                    }
                }
            }
            else
            {
                upit = (from item in _db.VoziloModeli select item);
                strIspis.BrSvihRedova = upit.Count();
                ispis = Expression.Call(typeof(Queryable), sorter.Poredak, new[] { typeof(VoziloModel), izraz.Type }, upit.Expression, Expression.Quote(lambda));
                listaIspisa = upit.Provider.CreateQuery<VoziloModel>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
            }
                     
            return (listaIspisa ,strIspis.BrSvihRedova);
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
