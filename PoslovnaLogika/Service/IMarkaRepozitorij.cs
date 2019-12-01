﻿using System.Collections.Generic;
using PoslovnaLogika.Models;

namespace PoslovnaLogika.Service
{
    interface IMarkaRepozitorij : IRepozitorij<VoziloMarka>
    {
        IEnumerable<IVoziloMarka> DohvatiVise(IFilter filter);
    }
}