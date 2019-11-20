using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Service
{
    class Repozitorij<TEntity> : IRepozitorij<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repozitorij(DbContext context)
        {
            Context = context;
        }

        public TEntity Dohvati(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> DohvatiSve()
        {
            return Context.Set<TEntity>();
        }
        
        public void Krairaj(TEntity objekt)
        {
            Context.Set<TEntity>().Add(objekt);
        }
        public void Uredi(TEntity objekt)
        {
            Context.Entry(objekt).State = EntityState.Modified;
        }
        public void Izbrisi(TEntity objekt)
        {
            Context.Set<TEntity>().Remove(objekt);
        }
    }
}
