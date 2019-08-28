using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Sortiranje : ISortiranje
    {        
        public string Poredak { get; set; }
        public string Stupac { get; set; }

        public void OdrediSortiranje(string sort)
        {
            this.Poredak = sort.Substring(0, 1);
            this.Stupac = sort.Substring(2);
        }
    }
}
