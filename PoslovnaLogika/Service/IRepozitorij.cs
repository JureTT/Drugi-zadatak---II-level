using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Service
{
    public interface IRepozitorij<TEntity> where TEntity : class
    {
        TEntity Dohvati(int id);
        IEnumerable<TEntity> DohvatiSve();
        
        void Kreiraj(TEntity objekt);
        void Uredi(TEntity objekt);
        void Izbrisi(TEntity objekt);        
    }
}
