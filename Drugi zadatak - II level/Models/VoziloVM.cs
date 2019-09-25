using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drugi_zadatak___II_level.Models
{
    public class VoziloVM : IVoziloVM
    {
        public int IdModel { get; set; }
        public string NazivModel { get; set; }
        public string Kratica { get; set; }
        public int IdMarka { get; set; }
        public string NazivMarka { get; set; }
    }
}