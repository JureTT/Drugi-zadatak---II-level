using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Vozilo : IVozilo
    {
        public int IdModel { get; set; }
        public string NazivModel { get; set; }
        public string Kratica { get; set; }
        public int IdMarka { get; set; }
        public string NazivMarka { get; set; }
    }
}
