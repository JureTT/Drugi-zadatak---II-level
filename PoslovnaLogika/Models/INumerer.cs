using System.Collections.Generic;

namespace PoslovnaLogika.Models
{
    public interface INumerer
    {
        int Str { get; set; }
        int BrRedova { get; set; }

        //dynamic ListaIspisa { get; set; }
        //List<VoziloMarka> MarkaStrana { get; set; }
        //List<VoziloModel> ModelStrana { get; set; }

        void UnesiBrRedova(int? brIspisa);
        void UnesiBrStr(int? strana);
    }
}