using PagedList;
using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Service
{
    class MarkaRepozitorij : Repozitorij<VoziloMarka>, IMarkaRepozitorij
    {
        public MarkaRepozitorij(VozilaDbContext context): base(context)
        {
        }

        public IEnumerable<IVoziloMarka> DohvatiVise(IFilter filter)
        {
            IEnumerable<IVoziloMarka> upit = VozilaDbContext.VoziloMarke.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()));
            return upit;
        }

        public VozilaDbContext VozilaDbContext
        {
            get { return Context as VozilaDbContext; }
        }
    }
}
