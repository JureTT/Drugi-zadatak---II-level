using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Service
{
    public class VoziloServis
    {
        public VozilaDbContext _db = new VozilaDbContext();

        #region MarkaCRUD
        public List<VoziloMarka> DohvatiMarke()
        {
            List<VoziloMarka> kolekcija = (from item in _db.VoziloMarke select item).ToList();
            return kolekcija;
        }

        public VoziloMarka DohvatiMarku(int idMarka)
        {
            VoziloMarka marka = _db.VoziloMarke.Find(idMarka);
            return marka;
        }
        
        public void KreirajMarku(VoziloMarka marka)
        {            
            _db.VoziloMarke.Add(marka);
            _db.SaveChanges();
        }

        public void UrediMarku(VoziloMarka marka)
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

        public List<VoziloModel> DohvatiListuModela(int idMarke)
        {
            List<VoziloModel> kolekcija = (from item in _db.VoziloModeli where item.IdMarke == idMarke select item).ToList();
            return kolekcija;
        }

        public VoziloModel DohvatiModel(int idModela)
        {
            VoziloModel model = _db.VoziloModeli.Find(idModela);
            return model;
        }

        public object KreirajModel(VoziloModel model)
        {
            _db.VoziloModeli.Add(model);
            _db.SaveChanges();
            return model;
        }

        public void UrediModel(VoziloModel model)
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
