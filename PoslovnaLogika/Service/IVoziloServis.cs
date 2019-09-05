using System.Collections.Generic;
using PoslovnaLogika.Models;
using PagedList;
using PagedList.Mvc;

namespace PoslovnaLogika.Service
{
    public interface IVoziloServis
    {        
        List<VoziloMarka> DohvatiMarke();
        (List<VoziloMarka>, int) DohvatiMarke(IVoziloSorter sorter, IFilter filter, IStranica stranica);
        //Stranica DohvatiMarke(IVoziloSorter sorter, IVoziloFilter filter, IStranica stranica);
        VoziloMarka DohvatiMarku(int idMarka);
        void IzbrisiMarku(int idMarke);
        void KreirajMarku(IVoziloMarka marka);
        void UrediMarku(IVoziloMarka marka);

        List<VoziloModel> DohvatiModele();
        (List<VoziloModel>, int) DohvatiModele(IVoziloSorter sorter, IFilter filter, IStranica stranica);
        //Stranica DohvatiModele(IVoziloSorter sorter, IVoziloFilter filter, IStranica stranica);
        //List<VoziloModel> DohvatiListuModela(int? idMarke);
        VoziloModel DohvatiModel(int idModela);
        void IzbrisiModel(int idModela);
        object KreirajModel(IVoziloModel model);
        void UrediModel(IVoziloModel model);
    }
}