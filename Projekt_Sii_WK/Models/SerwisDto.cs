using AutoMapper;
using Projekt_Sii_WK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Models
{
    public class SerwisDto
    {
        public int Id { get; set; }

        public int Garaz { get; set; }

        public string Pracownik { get; set; }

        public string Rodzaj_wady { get; set; }
        public int Numer_tel { get; set; }
    }
}
