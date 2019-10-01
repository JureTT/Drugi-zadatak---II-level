using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Odgovor : IOdgovor
    {
        public int Redovi { get; set; }
        public IPagedList<IVoziloMarka> ListaMarke { get; set; }
        public IPagedList<IVoziloModel> ListaModela { get; set; }
        public IPagedList<IVozilo> ListaVozila { get; set; }
    }
}
