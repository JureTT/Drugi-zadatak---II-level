using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Service
{
    class JedinicaRada : IJedinicaRada
    {
        private readonly VozilaDbContext _context;

        public JedinicaRada(VozilaDbContext context)
        {
            _context = context;
            Marka = new MarkaRepozitorij(_context);
            Model = new ModelRepozitorij(_context);
        }

        public IMarkaRepozitorij Marka { get; private set; }
        public IModelRepozitorij Model { get; private set; }

        public int Spremi()
        {
            return _context.SaveChanges();
        }

        //public void Odbaci()
        //{
        //    _context.Dispose();
        //}
    }
}
