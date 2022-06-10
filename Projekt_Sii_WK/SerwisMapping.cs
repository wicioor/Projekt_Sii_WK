using AutoMapper;
using Projekt_Sii_WK.Entities;
using Projekt_Sii_WK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK
{
    public class SerwisMapping : Profile
    {
        public SerwisMapping()
        {
            CreateMap<Serwis_samoch, SerwisDto>()
                .ForMember(x => x.Numer_tel, y => y.MapFrom(z => z.Klient.Numer_tel));

            CreateMap<UtworzserwisDto, Serwis_samoch>()
                .ForMember(s => s.Pojazd,
                p => p.MapFrom(dto => new Pojazd()
                { Rejestracja = dto.Rejestracja, Marka = dto.Marka, Model = dto.Model }));

            CreateMap<UtworzserwisDto, Serwis_samoch>()
                .ForMember(s => s.Klient,
                k => k.MapFrom(dto => new Klient()
                { Imie = dto.Imie, Nazwisko = dto.Nazwisko, Numer_tel = dto.Numer_tel}));
        }
    }
}
