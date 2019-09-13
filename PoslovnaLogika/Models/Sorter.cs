using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Sorter : ISorter
    {        
        public string Poredak { get; set; }
        public string Stupac { get; set; }

        public Sorter(string sort)
        {
            this.Poredak = sort.Substring(0, 1);
            this.Stupac = sort.Substring(2);
        }
    }
}
