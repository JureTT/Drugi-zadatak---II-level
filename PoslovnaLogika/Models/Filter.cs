using PoslovnaLogika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Filter : IFilter
    {        
        public string PretragaUpita { get; set; }
        public int? IdMarke { get; set; }

        public Filter(string pretraga)
        {
            this.PretragaUpita = pretraga;
        }
        public Filter(string pretraga, int? idMarke) 
        {
            this.PretragaUpita = pretraga;
            this.IdMarke = idMarke;
        }
    }
}
