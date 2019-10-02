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
        public List<Vozilo> DohvatiVozila()
        {
            List<Vozilo> lista = (from model in _db.VoziloModeli
                                      join marka in _db.VoziloMarke
                                      on model.IdMarke equals marka.Id
                                      select new Vozilo
                                      {
                                          IdMarka = marka.Id,
                                          NazivMarka = marka.Naziv,
                                          Kratica = marka.Kratica,
                                          IdModel = model.Id,
                                          NazivModel = model.Naziv
                                      }).ToList();
            return lista;
        }
        public IOdgovor DohvatiVozila(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IQueryable<IVozilo> upit = null;
            List<IVozilo> listaIspisa = null;
            IOdgovor povrat = new Odgovor();

            if (!String.IsNullOrEmpty(filter.PretragaUpita) || filter.IdMarke > 0 || filter.IdMarke != null)
            {
                if (!String.IsNullOrEmpty(filter.PretragaUpita) && filter.IdMarke > 0 && filter.IdMarke != null)
                {
                    upit = (from model in _db.VoziloModeli
                            join marka in _db.VoziloMarke
                            on model.IdMarke equals marka.Id
                            where model.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) && model.IdMarke == filter.IdMarke
                            select new Vozilo
                            {
                                IdMarka = marka.Id,
                                NazivMarka = marka.Naziv,
                                Kratica = marka.Kratica,
                                IdModel = model.Id,
                                NazivModel = model.Naziv
                            });  
                    povrat.Redovi = upit.Count();

                    switch (sorter.Stupac)
                    {
                        case "Id":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdModel).ToList() : upit.OrderByDescending(x => x.IdModel).ToList();
                            break;
                        case "NazivMarke":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivMarka).ToList() : upit.OrderByDescending(x => x.NazivMarka).ToList();
                            break;
                        case "NazivModela":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivModel).ToList() : upit.OrderByDescending(x => x.NazivModel).ToList();
                            break;
                        case "Kratica":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                            break;
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(filter.PretragaUpita))
                    {
                        upit = (from model in _db.VoziloModeli
                                join marka in _db.VoziloMarke
                                on model.IdMarke equals marka.Id
                                where model.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower())
                                select new Vozilo
                                {
                                    IdMarka = marka.Id,
                                    NazivMarka = marka.Naziv,
                                    Kratica = marka.Kratica,
                                    IdModel = model.Id,
                                    NazivModel = model.Naziv
                                }); 
                        povrat.Redovi = upit.Count();

                        switch (sorter.Stupac)
                        {
                            case "Id":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdModel).ToList() : upit.OrderByDescending(x => x.IdModel).ToList();
                                break;
                            case "NazivMarke":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivMarka).ToList() : upit.OrderByDescending(x => x.NazivMarka).ToList();
                                break;
                            case "NazivModela":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivModel).ToList() : upit.OrderByDescending(x => x.NazivModel).ToList();
                                break;
                            case "Kratica":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                                break;
                        }
                    }

                    if (filter.IdMarke > 0 && filter.IdMarke != null)
                    {
                        upit = (from model in _db.VoziloModeli
                                join marka in _db.VoziloMarke
                                on model.IdMarke equals marka.Id
                                where model.IdMarke == filter.IdMarke
                                select new Vozilo
                                {
                                    IdMarka = marka.Id,
                                    NazivMarka = marka.Naziv,
                                    Kratica = marka.Kratica,
                                    IdModel = model.Id,
                                    NazivModel = model.Naziv
                                }); 
                        povrat.Redovi = upit.Count();

                        switch (sorter.Stupac)
                        {
                            case "Id":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdModel).ToList() : upit.OrderByDescending(x => x.IdModel).ToList();
                                break;
                            case "NazivMarke":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivMarka).ToList() : upit.OrderByDescending(x => x.NazivMarka).ToList();
                                break;
                            case "NazivModela":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivModel).ToList() : upit.OrderByDescending(x => x.NazivModel).ToList();
                                break;
                            case "Kratica":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                                break;
                        }
                    }
                }
            }
            else
            {
                upit = (from model in _db.VoziloModeli
                        join marka in _db.VoziloMarke
                        on model.IdMarke equals marka.Id
                        select new Vozilo
                        {
                            IdMarka = marka.Id,
                            NazivMarka = marka.Naziv,
                            Kratica = marka.Kratica,
                            IdModel = model.Id,
                            NazivModel = model.Naziv
                        }); 
                povrat.Redovi = upit.Count();

                switch (sorter.Stupac)
                {
                    case "Id":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdModel).ToList() : upit.OrderByDescending(x => x.IdModel).ToList();
                        break;
                    case "NazivMarke":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivMarka).ToList() : upit.OrderByDescending(x => x.NazivMarka).ToList();
                        break;
                    case "NazivModela":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.NazivModel).ToList() : upit.OrderByDescending(x => x.NazivModel).ToList();
                        break;
                    case "Kratica":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                        break;
                }
            }

            povrat.ListaIspisa = listaIspisa.ToPagedList<IVozilo>(stranica.Str, stranica.BrRedova);

            return povrat;
        }
        #endregion Vozilo

        #region MarkaCRUD
        public List<VoziloMarka> DohvatiMarke()
        {
            List<VoziloMarka> kolekcija = _db.VoziloMarke.ToList();
            return kolekcija;
        }
        public IOdgovor DohvatiMarke(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IOdgovor povrat = new Odgovor();
            IQueryable<VoziloMarka> upit = null;
            List<VoziloMarka> listaIspisa = null;
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

            if (!String.IsNullOrEmpty(filter.PretragaUpita))
            {
                //kolekcija = _db.VoziloMarke.SqlQuery("SELECT * FROM VoziloMarkas WHERE Naziv LIKE '%" + filter.Naziv + "%' " + sorter.Sort + " ;").ToList();
                //kolekcija = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.Naziv.ToLower()) select item).OrderBy(x => x.GetType().ToString() == sorter.Stupac);
                //upit = (from item in _db.VoziloMarke where item.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) select item);
                upit = _db.VoziloMarke.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()));
                povrat.Redovi = upit.Count();
                //ispis = Expression.Call(typeof(Queryable), sorter.Poredak, new[] { typeof(VoziloMarka), izraz.Type }, upit.Expression, Expression.Quote(lambda));

                switch (sorter.Stupac)
                {
                    case "Id":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id).ToList() : upit.OrderByDescending(x => x.Id).ToList();
                        break;
                    case "Naziv":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv).ToList() : upit.OrderByDescending(x => x.Naziv).ToList();
                        break;
                    case "Kratica":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                        break;
                }
                //listaIspisa = upit.Provider.CreateQuery<VoziloMarka>(ispis).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                //listaIspisa = upit.OrderBy(sorter.Stupac + " " + sorter.Poredak).Skip((strIspis.Str - 1) * strIspis.BrRedova).Take(strIspis.BrRedova).ToList();
                //OrderBy(lambda,Compile())
                //OrderBy(item => svojstvo.GetValue(item))
                //OrderBy(item => item.GetType().GetProperty(property).GetValue(item))
            }
            else
            {
                upit = _db.VoziloMarke;
                povrat.Redovi = upit.Count();

                switch (sorter.Stupac)
                {
                    case "Id":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id).ToList() : upit.OrderByDescending(x => x.Id).ToList();
                        break;
                    case "Naziv":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv).ToList() : upit.OrderByDescending(x => x.Naziv).ToList();
                        break;
                    case "Kratica":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                        break;
                }
            }

            povrat.ListaIspisa = listaIspisa.ToPagedList<IVoziloMarka>(stranica.Str, stranica.BrRedova);
            
            return povrat;
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
        public List<VoziloModel> DohvatiModele()
        {
            List<VoziloModel> kolekcija = (from item in _db.VoziloModeli select item).ToList();
            return kolekcija;
        }
        public IOdgovor DohvatiModele(ISorter sort, IFilter filter, INumerer stranica)
        {
            Numerer strIspis = (Numerer)stranica;
            Sorter sorter = (Sorter)sort;
            IQueryable<VoziloModel> upit = null;
            List<VoziloModel> listaIspisa = null;
            IOdgovor povrat = new Odgovor();

            if (!String.IsNullOrEmpty(filter.PretragaUpita) || filter.IdMarke > 0 || filter.IdMarke != null)
            {
                if (!String.IsNullOrEmpty(filter.PretragaUpita) && filter.IdMarke > 0 && filter.IdMarke != null)
                {
                    upit = _db.VoziloModeli.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) && x.IdMarke == filter.IdMarke);
                    povrat.Redovi = upit.Count();

                    switch (sorter.Stupac)
                    {
                        case "Id":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id).ToList() : upit.OrderByDescending(x => x.Id).ToList();
                            break;
                        case "IdMarke":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdMarke).ToList() : upit.OrderByDescending(x => x.IdMarke).ToList();
                            break;
                        case "Naziv":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv).ToList() : upit.OrderByDescending(x => x.Naziv).ToList();
                            break;
                        case "Kratica":
                            listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                            break;
                    }
                }
                else
                { 
                    if (!String.IsNullOrEmpty(filter.PretragaUpita))
                    {
                        upit = _db.VoziloModeli.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()));
                        povrat.Redovi = upit.Count();

                        switch (sorter.Stupac)
                        {
                            case "Id":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id).ToList() : upit.OrderByDescending(x => x.Id).ToList();
                                break;
                            case "IdMarke":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdMarke).ToList() : upit.OrderByDescending(x => x.IdMarke).ToList();
                                break;
                            case "Naziv":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv).ToList() : upit.OrderByDescending(x => x.Naziv).ToList();
                                break;
                            case "Kratica":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                                break;
                        }
                    }

                    if (filter.IdMarke > 0 && filter.IdMarke != null)
                    {
                        upit = _db.VoziloModeli.Where(x => x.IdMarke == filter.IdMarke);
                        povrat.Redovi = upit.Count();

                        switch (sorter.Stupac)
                        {
                            case "Id":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id).ToList() : upit.OrderByDescending(x => x.Id).ToList();
                                break;
                            case "IdMarke":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdMarke).ToList() : upit.OrderByDescending(x => x.IdMarke).ToList();
                                break;
                            case "Naziv":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv).ToList() : upit.OrderByDescending(x => x.Naziv).ToList();
                                break;
                            case "Kratica":
                                listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                                break;
                        }
                    }
                }
            }
            else
            {
                upit = _db.VoziloModeli;
                povrat.Redovi = upit.Count();

                switch (sorter.Stupac)
                {
                    case "Id":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id).ToList() : upit.OrderByDescending(x => x.Id).ToList();
                        break;
                    case "IdMarke":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.IdMarke).ToList() : upit.OrderByDescending(x => x.IdMarke).ToList();
                        break;
                    case "Naziv":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv).ToList() : upit.OrderByDescending(x => x.Naziv).ToList();
                        break;
                    case "Kratica":
                        listaIspisa = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica).ToList() : upit.OrderByDescending(x => x.Kratica).ToList();
                        break;
                }
            }

            povrat.ListaIspisa = listaIspisa.ToPagedList<IVoziloModel>(stranica.Str, stranica.BrRedova);

            return povrat;
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
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();
            return model;
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
