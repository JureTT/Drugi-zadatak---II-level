using PoslovnaLogika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class VoziloFilter : IFilteri
    {        
        public string Naziv { get; set; }
        public int? IdMarke { get; set; }

        public void UnesiFiltere(string naziv)
        {
            this.Naziv = naziv;
        }
        public void UnesiFiltere(string naziv, int? idMarke) 
        {
            this.Naziv = naziv;
            this.IdMarke = idMarke;
        }
    }
}
