using AutoMapper;
using PoslovnaLogika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drugi_zadatak___II_level.Models
{
    public class Mape
    {
        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<VoziloMarka, VoziloMarkaVM>();
            cfg.CreateMap<VoziloModel, VoziloModelVM>();
            cfg.CreateMap<VoziloMarkaVM, VoziloMarka>();
            cfg.CreateMap<VoziloModelVM, VoziloModel>();
            cfg.CreateMap<Vozilo, VoziloVM>();
        });
        public IMapper maper => configuration.CreateMapper();
    }
}