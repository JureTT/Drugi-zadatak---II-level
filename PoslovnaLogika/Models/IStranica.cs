using System.Collections.Generic;

namespace PoslovnaLogika.Models
{
    public interface IStranica
    {
        int Strana { get; set; }
        int BrIspisa { get; set; }
        int BrStrana { get; set; }
        int BrSvihIspisa { get; set; }

        //dynamic ListaIspisa { get; set; }
        //List<VoziloMarka> MarkaStrana { get; set; }
        //List<VoziloModel> ModelStrana { get; set; }

        void UnesiBrIspisa(int? brIspisa);
        void UnesiStranice(int? strana);
    }
}