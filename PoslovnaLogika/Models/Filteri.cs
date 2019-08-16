using PoslovnaLogika.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Filteri : IFilteri
    {
        string naziv;
        string kratica;
        int? idMarke;

        public string Naziv { get => naziv; set => naziv = value; }
        public string Kratica { get => kratica; set => kratica = value; }
        public int? IdMarke { get => idMarke; set => idMarke = value; }

        public void UnesiFiltere(string naziv, string kratica)
        {
            this.Naziv = naziv;
            this.Kratica = kratica;
        }
        public void UnesiFiltere(string naziv, int? idMarke)
        {
            this.Naziv = naziv;
            this.idMarke = idMarke;
        }
    }
}
