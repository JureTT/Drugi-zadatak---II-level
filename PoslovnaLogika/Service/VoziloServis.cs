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
        JedinicaRada jedinicaRada = new JedinicaRada(new VozilaDbContext());
               
        #region MarkaCRUD
        public IList<IVoziloMarka> DohvatiMarke()
        {
            IList<IVoziloMarka> kolekcija = jedinicaRada.Marka.DohvatiSve().ToList<IVoziloMarka>();
            return kolekcija;
        }
        public IPagedList<IVoziloMarka> DohvatiMarke(ISorter sorter, IFilter filter, INumerer stranica)
        {
            IEnumerable<IVoziloMarka> upit = null;
            IPagedList<IVoziloMarka> kolekcija = null;
            
            //NAPOMENA: CIJELI UVJET SVEDEN NA SAMO SLJEDEĆU LINIJU KODA            
            upit = (String.IsNullOrEmpty(filter.PretragaUpita))? jedinicaRada.Marka.DohvatiSve() : jedinicaRada.Marka.DohvatiVise(filter);

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

            kolekcija = upit.ToPagedList(stranica.Str, stranica.BrRedova);
            
            return kolekcija;
        }

        public IVoziloMarka DohvatiMarku(int idMarka)
        {
            IVoziloMarka marka = jedinicaRada.Marka.Dohvati(idMarka);
            return marka;
        }
        
        public void KreirajMarku(IVoziloMarka marka)
        {
            jedinicaRada.Marka.Kreiraj((VoziloMarka)marka);
            jedinicaRada.Spremi();
        }

        public void UrediMarku(IVoziloMarka marka)
        {
            jedinicaRada.Marka.Uredi((VoziloMarka)marka);
            jedinicaRada.Spremi();
        }

        public void IzbrisiMarku(int idMarke)
        {
            IVoziloMarka marka = jedinicaRada.Marka.Dohvati(idMarke);
            jedinicaRada.Marka.Izbrisi((VoziloMarka)marka);
            jedinicaRada.Spremi();
        }

        #endregion

        #region ModelCRUD
        public IList<IVoziloModel> DohvatiModele()
        {
            IList<IVoziloModel> kolekcija = jedinicaRada.Model.DohvatiSve().ToList<IVoziloModel>();
            return kolekcija;
        }
        public IPagedList<IVoziloModel> DohvatiModele(ISorter sorter, IFilter filter, INumerer stranica)
        {
            IEnumerable<IVoziloModel> upit = null;
            IPagedList<IVoziloModel> kolekcija = null;

            //NAPOMENA: CIJELI VELIKI UVJET SVEDEN NA SLJEDEĆE LINIJE KODA
            upit = (!String.IsNullOrEmpty(filter.PretragaUpita) || filter.IdMarke > 0)
                ? upit = (!String.IsNullOrEmpty(filter.PretragaUpita) && filter.IdMarke > 0)
                    ? jedinicaRada.Model.DohvatiVise(filter)
                    : jedinicaRada.Model.DohvatiViseIli(filter)
                : jedinicaRada.Model.DohvatiSve();            

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

            kolekcija = upit.ToPagedList(stranica.Str, stranica.BrRedova);

            return kolekcija;
        }
        
        public IVoziloModel DohvatiModel(int idModela)
        {
            IVoziloModel model = jedinicaRada.Model.Dohvati(idModela);
            return model;
        }

        public void KreirajModel(IVoziloModel model)
        {
            jedinicaRada.Model.Kreiraj((VoziloModel)model);
            jedinicaRada.Spremi();
        }

        public void UrediModel(IVoziloModel model)
        {
            jedinicaRada.Model.Uredi((VoziloModel)model);
            jedinicaRada.Spremi();
        }

        public void IzbrisiModel(int idModela)
        {
            IVoziloModel model = jedinicaRada.Model.Dohvati(idModela);
            jedinicaRada.Model.Izbrisi((VoziloModel)model);
            jedinicaRada.Spremi();
        }
        #endregion
    }
}
