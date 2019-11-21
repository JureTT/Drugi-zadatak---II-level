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

        public IEnumerable<IVoziloMarka> DohvatiVise(ISorter sorter, IFilter filter)
        {
            IQueryable<IVoziloMarka> upit = null;
            upit = (String.IsNullOrEmpty(filter.PretragaUpita)) ? VozilaDbContext.VoziloMarke : VozilaDbContext.VoziloMarke.Where(x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()));

            switch (sorter.Stupac)
            {
                case "Id":
                    upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Id) : upit.OrderByDescending(x => x.Id);
                    break;
                case "Naziv":
                    upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Naziv) : upit.OrderByDescending(x => x.Naziv);
                    break;
                case "Kratica":
                    upit = (sorter.Poredak == "A") ? upit.OrderBy(x => x.Kratica) : upit.OrderByDescending(x => x.Kratica);
                    break;
            }
            return upit;
        }

        public VozilaDbContext VozilaDbContext
        {
            get { return Context as VozilaDbContext; }
        }
    }
}
