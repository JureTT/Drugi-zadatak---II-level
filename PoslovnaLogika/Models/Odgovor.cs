using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Models
{
    public class Odgovor<T> : IOdgovor<T>
    {
        public IPagedList<T> ListaIspisa { get; set; }     
    }
}
