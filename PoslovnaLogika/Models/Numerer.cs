using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Numerer : INumerer
    {
        public int Str { get; set; }
        public int BrStr { get; set; }
        public int BrRedova { get; set; }
        public int BrSvihRedova { get; set; }

        //public dynamic ListaIspisa { get; set; }    // -- radi, ali idemo na drugu soluciju
        //public List<VoziloMarka> MarkaStrana { get; set; }    //privremeno, sredi imena varijabli kasnije
        //public List<VoziloModel> ModelStrana { get; set; }    //privremeno, sredi imena varijabli kasnije

        public Numerer()
        {
            this.BrRedova = 10;
        }
        public void UnesiBrStr(int? str)
        {
            this.Str = (int)str;
        }
        public void UnesiBrRedova(int? brRedova)
        {
            this.BrRedova = (brRedova == null) ? 10 : (int)brRedova;
        }

        //public void odrediBrStranica()
        //{
        //    this.BrStrana = (BrSvihIspisa % BrIspisa != 0) ? (BrSvihIspisa / BrIspisa) + 1 : BrSvihIspisa / BrIspisa;
        //}
    }
} 
