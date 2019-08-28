using System.Collections.Generic;
using PoslovnaLogika.Models;
using PagedList;
using PagedList.Mvc;

namespace PoslovnaLogika.Service
{
    public interface IVoziloServis
    {        
        List<VoziloMarka> DohvatiMarke();
        //List<VoziloMarka> DohvatiMarke(ISortiranje sorter, IFilteri filter, IStranice stranica);
        VoziloStranica DohvatiMarke(IVoziloSorter sorter, IVoziloFilter filter, IVoziloStranica stranica);
        VoziloMarka DohvatiMarku(int idMarka);
        void IzbrisiMarku(int idMarke);
        void KreirajMarku(IVoziloMarka marka);
        void UrediMarku(IVoziloMarka marka);

        List<VoziloModel> DohvatiModele();
        //List<VoziloModel> DohvatiModele(ISortiranje sorter, IFilteri filter, IStranice stranica);
        VoziloStranica DohvatiModele(IVoziloSorter sorter, IVoziloFilter filter, IVoziloStranica stranica);
        //List<VoziloModel> DohvatiListuModela(int? idMarke);
        VoziloModel DohvatiModel(int idModela);
        void IzbrisiModel(int idModela);
        object KreirajModel(IVoziloModel model);
        void UrediModel(IVoziloModel model);
    }
}