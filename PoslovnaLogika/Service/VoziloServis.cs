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
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace PoslovnaLogika.Service
{
    public class VoziloServis : IVoziloServis
    {
        public VozilaDbContext _db = new VozilaDbContext();
       
        #region Vozilo
        public IList<IVoziloModel> DohvatiVozila()
        {
            var azuriranje = _db.Database.ExecuteSqlCommand("UPDATE VoziloModels SET VoziloMarka_Id = IdMarke;");
            IList<IVoziloModel> kolekcija = _db.VoziloModeli.Include(x => x.VoziloMarka).ToList<IVoziloModel>();
            //List<VoziloMarka> list = _db.VoziloMarke.ToList();
            //foreach (VoziloModel item in lista)
            //{
            //    VoziloMarka marka = list.Where(x => x.Id == item.IdMarke).Single();
            //    item.VoziloMarka = marka;
            //}
            return kolekcija;
        }
        public IList<IVoziloModel> DohvatiVozila(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IQueryable<VoziloModel> upit = null;
            IList<IVoziloModel> kolekcija = null;
            var azuriranje = _db.Database.ExecuteSqlCommand("UPDATE VoziloModels SET VoziloMarka_Id = IdMarke;");
                        
            upit = (!String.IsNullOrEmpty(filter.PretragaUpita) || filter.IdMarke > 0)
                ?
                upit = (!String.IsNullOrEmpty(filter.PretragaUpita) && filter.IdMarke > 0)
                    ?
                    _db.VoziloModeli.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) && x.IdMarke == filter.IdMarke)
                    :
                    _db.VoziloModeli.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) || x.IdMarke == filter.IdMarke)
                :
                _db.VoziloModeli;


            switch (sorter.Stupac)
                {
                    case "Id":
                        upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id) : upit.OrderByDescending(x => x.Id);
                        break;
                    case "NazivMarke":
                        upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.VoziloMarka.Naziv) : upit.OrderByDescending(x => x.VoziloMarka.Naziv);
                        break;
                    case "NazivModela":
                        upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv) : upit.OrderByDescending(x => x.Naziv);
                        break;
                    case "Kratica":
                        upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica) : upit.OrderByDescending(x => x.Kratica);
                        break;
                }

            kolekcija = upit.ToList<IVoziloModel>();

            return kolekcija;
        }
        #endregion Vozilo

        #region MarkaCRUD
        public IList<IVoziloMarka> DohvatiMarke()
        {
            IList<IVoziloMarka> kolekcija = _db.VoziloMarke.ToList<IVoziloMarka>();
            return kolekcija;
        }
        public IPagedList<IVoziloMarka> DohvatiMarke(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IQueryable<VoziloMarka> upit = null;
            IPagedList<IVoziloMarka> kolekcija = null;
            //sorter.Poredak = (sorter.Poredak == "A") ? "ASC" : "DESC";
            //sorter.Poredak = (sorter.Poredak == "A") ? "OrderBy" : "OrderByDescending";

            //var parametar = Expression.Parameter(typeof(VoziloMarka), "item");      //  -- kreiranje parametra
            //var izraz = Expression.Property(parametar, sorter.Stupac);
            //var konverzija = Expression.Convert(izraz, typeof(object));
            //var lambda = Expression.Lambda<Func<VoziloMarka, object>>(konverzija, parametar);
            //var lambda = Expression.Lambda(izraz, parametar);
            //MethodCallExpression ispis = null;
            //PropertyInfo svojstvo = typeof(VoziloMarka).GetProperty(sorter.Stupac);

            //string upit = "SELECT * FROM VoziloMarkas" ORDER BY " + sorter.Stupac + " " + sorter.Poredak + "; ";
            //List<VoziloMarka> kolekcija = _db.VoziloMarke.SqlQuery("SELECT* FROM VoziloMarkas " + sorter.Sort + "; ").ToList();

            //kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Naziv LIKE '%" + filter.Naziv + "%' " + sorter.Sort + " ;").ToList();
            //kolekcija = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).OrderBy(x => x.GetType().ToString() == sorter.Stupac);
            //upit = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) select item);
            
            //NAPOMENA: CIJELI UVJET SVEDEN NA SAMO SLJEDEĆU LINIJU KODA
            upit = (String.IsNullOrEmpty(filter.PretragaUpita))? _db.VoziloMarke : _db.VoziloMarke.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()));
            
            //ispis = Expression.Call(typeof(Queryable), sorter.Poredak, new[] { typeof(VoziloMarka), izraz.Type }, upit.Expression, Expression.Quote(lambda));

                switch (sorter.Stupac)
                {
                    case "Id":
                        upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id) : upit.OrderByDescending(x => x.Id);
                        break;
                    case "Naziv":
                        upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv) : upit.OrderByDescending(x => x.Naziv);
                        break;
                    case "Kratica":
                        upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica) : upit.OrderByDescending(x => x.Kratica);
                        break;
                }
                //kolekcija = upit.Provider.CreateQuery<VoziloMarka>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                //kolekcija = upit.OrderBy(sorter.Stupac + " " + sorter.Poredak).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                //OrderBy(lambda,Compile())
                //OrderBy(item => svojstvo.GetValue(item))
                //OrderBy(item => item.GetType().GetProperty(property).GetValue(item))
           
            kolekcija = upit.ToPagedList<IVoziloMarka>(stranica.Str, stranica.BrRedova);
            
            return kolekcija;
        }
        //public List<VoziloMarka> DohvatiListuMarki(int? idMarke)
        //{
        //    List<VoziloMarka> kolekcija = (from item in _db.VoziloMarke where item.Id == idMarke select item).ToList();
        //    return kolekcija;
        //}

        public IVoziloMarka DohvatiMarku(int idMarka)
        {
            IVoziloMarka marka = _db.VoziloMarke.Find(idMarka);
            return marka;
        }
        
        public void KreirajMarku(IVoziloMarka marka)
        {            
            _db.Entry(marka).State = EntityState.Added;
            _db.SaveChanges();
        }

        public void UrediMarku(IVoziloMarka marka)
        {   
            _db.Entry(marka).State = EntityState.Modified;
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
        public IList<IVoziloModel> DohvatiModele()
        {
            IList<IVoziloModel> kolekcija = _db.VoziloModeli.ToList<IVoziloModel>();
            return kolekcija;
        }
        public IPagedList<IVoziloModel> DohvatiModele(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IQueryable<VoziloModel> upit = null;
            IPagedList<IVoziloModel> kolekcija = null;

            //NAPOMENA: CIJELI VELIKI UVJET SVEDEN NA SLJEDEĆE LINIJE KODA
            upit = (!String.IsNullOrEmpty(filter.PretragaUpita) || filter.IdMarke > 0 )
                ?
                upit = (!String.IsNullOrEmpty(filter.PretragaUpita) && filter.IdMarke > 0 ) 
                    ?           
                    _db.VoziloModeli.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) && x.IdMarke == filter.IdMarke)
                    :
                    _db.VoziloModeli.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) || x.IdMarke == filter.IdMarke)
                :
                _db.VoziloModeli;
            

            switch (sorter.Stupac)
            {
                case "Id":
                    upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id) : upit.OrderByDescending(x => x.Id);
                    break;
                case "IdMarke":
                    upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdMarke) : upit.OrderByDescending(x => x.IdMarke);
                    break;
                case "Naziv":
                    upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv) : upit.OrderByDescending(x => x.Naziv);
                    break;
                case "Kratica":
                    upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica) : upit.OrderByDescending(x => x.Kratica);
                    break;
            }

            kolekcija = upit.ToPagedList<IVoziloModel>(stranica.Str, stranica.BrRedova);

            return kolekcija;
        }
        //// -- izgleda da je ova metoda nepotrebna uz nove promjene
        //public List<VoziloModel> DohvatiListuModela(int? idMarke)
        //{
        //    List<VoziloModel> kolekcija = (from item in _db.VoziloModeli where item.IdMarke == idMarke select item).ToList();
        //    return kolekcija;
        //}

        public IVoziloModel DohvatiModel(int idModela)
        {
            IVoziloModel model = _db.VoziloModeli.Find(idModela);
            return model;
        }

        public void KreirajModel(IVoziloModel model)
        {
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();
        }

        public void UrediModel(IVoziloModel model)
        {
            _db.Entry(model).State = EntityState.Modified;
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
