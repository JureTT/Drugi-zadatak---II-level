using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoslovnaLogika.Service
{
    class ModelRepozitorij : Repozitorij<VoziloModel>, IModelRepozitorij
    {
        public ModelRepozitorij(VozilaDbContext context) : base(context)
        {
        }

        public IEnumerable<IVoziloModel> DohvatiVise(IFilter filter)
        {
            IEnumerable<IVoziloModel> upit = VozilaDbContext.VoziloModeli.Where(
                x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower()) 
                && x.IdMarke == filter.IdMarke);
            return upit;
        }

        public IEnumerable<IVoziloModel> DohvatiViseIli(IFilter filter)
        {
            IEnumerable<IVoziloModel> upit = VozilaDbContext.VoziloModeli.Where(
                x => x.Naziv.ToLower().Contains(filter.PretragaUpita.ToLower())
                || x.IdMarke == filter.IdMarke);
            return upit;
        }

        public VozilaDbContext VozilaDbContext
        {
            get { return Context as VozilaDbContext; }
        }
    }
}
