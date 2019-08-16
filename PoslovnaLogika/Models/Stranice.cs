using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Stranice : IStranice
    {
        int brIspisa = 10;
        int strana;
        public int Strana { get => strana; set => strana = value; }
        public int BrIspisa { get => brIspisa; set => brIspisa = value; }

        public void UnesiStranice(int? strana)
        {
            this.Strana = (strana == null) ? this.Strana = 1 : this.Strana = (int)strana;
        }

        //public void UnesiBrIspisa(int? brIspisa)
        //{
        //    this.BrIspisa = (brIspisa == null) ? this.brIspisa = 10 : this.BrIspisa = (int)brIspisa; 
        //}
    }
}
