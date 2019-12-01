using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Vozilo : IVozilo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Kratica { get; set; }
    }
}
