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
            cfg.CreateMap<IVoziloModel, IVozilo>()  // NAPOMENA: s obzirom da su različiti modeli mora biti posebno mapa za clasu/model i posebno za interfejs
            .ForMember(cilj => cilj.IdModel, opcija => opcija.MapFrom(izvor => izvor.Id))
            .ForMember(cilj => cilj.NazivModel, opcija => opcija.MapFrom(izvor => izvor.Naziv))
            .ForMember(cilj => cilj.Kratica, opcija => opcija.MapFrom(izvor => izvor.Kratica))
            .ForMember(cilj => cilj.IdMarka, opcija => opcija.MapFrom(izvor => izvor.VoziloMarka.Id))
            .ForMember(cilj => cilj.NazivMarka, opcija => opcija.MapFrom(izvor => izvor.VoziloMarka.Naziv));
            cfg.CreateMap<Vozilo, VoziloVM>();
        });
        public IMapper maper => configuration.CreateMapper();
    }
}