using System.Collections.Generic;
using PoslovnaLogika.Models;

namespace PoslovnaLogika.Service
{
    public interface IVoziloServis
    {        
        List<VoziloMarka> DohvatiMarke();
        VoziloMarka DohvatiMarku(int idMarka);
        void IzbrisiMarku(int idMarke);
        void KreirajMarku(VoziloMarka marka);
        void UrediMarku(VoziloMarka marka);

        List<VoziloModel> DohvatiModele();
        List<VoziloModel> DohvatiListuModela(int? idMarke);
        VoziloModel DohvatiModel(int idModela);
        void IzbrisiModel(int idModela);
        object KreirajModel(VoziloModel model);
        void UrediModel(VoziloModel model);
    }
}