using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Stranice : IStranice
    {
        public int Strana { get; set; }
        public int BrStrana { get; set; }
        public int BrIspisa { get; set; }
        public int BrSvihIspisa { get; set; }

        public List<VoziloMarka> MarkaStrana { get; set; } //privremeno, sredi imena varijabli kasnije
        public List<VoziloModel> ModelStrana { get; set; } //privremeno, sredi imena varijabli kasnije

        public Stranice()
        {
            this.BrIspisa = 10;
        }
        public void UnesiStranice(int? strana)
        {
            this.Strana = (int)strana;
        }
        public void UnesiBrIspisa(int? brIspisa)
        {
            this.BrIspisa = (brIspisa == null) ? 10 : (int)brIspisa;
        }

        //public void odrediBrStranica()
        //{
        //    this.BrStrana = (BrSvihIspisa % BrIspisa != 0) ? (BrSvihIspisa / BrIspisa) + 1 : BrSvihIspisa / BrIspisa;
        //}
    }
} 
