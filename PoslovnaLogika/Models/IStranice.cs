using System.Collections.Generic;

namespace PoslovnaLogika.Models
{
    public interface IStranice
    {
        int BrIspisa { get; set; }
        int BrSvihIspisa { get; set; }
        List<VoziloMarka> MarkaStrana { get; set; }
        int Strana { get; set; }

        void UnesiStranice(int? strana);
    }
}