using System.Collections.Generic;
using PoslovnaLogika.Models;

namespace PoslovnaLogika.Service
{
    interface IModelRepozitorij : IRepozitorij<VoziloModel>
    {
        IEnumerable<IVoziloModel> DohvatiVise(IFilter filter);
        IEnumerable<IVoziloModel> DohvatiViseIli(IFilter filter);
    }
}