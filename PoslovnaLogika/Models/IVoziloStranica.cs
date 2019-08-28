using System.Collections.Generic;

namespace PoslovnaLogika.Models
{
    public interface IVoziloStranica
    {
        int BrIspisa { get; set; }
        int BrStrana { get; set; }
        int BrSvihIspisa { get; set; }
        List<VoziloMarka> MarkaStrana { get; set; }
        List<VoziloModel> ModelStrana { get; set; }
        int Strana { get; set; }

        void UnesiBrIspisa(int? brIspisa);
        void UnesiStranice(int? strana);
    }
}