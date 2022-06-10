using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Models
{
    public class UtworzserwisDto
    {
        public int Id { get; set; }

        public int Garaz { get; set; }

        public string Pracownik { get; set; }

        public string Rodzaj_wady { get; set; }

        public string Rejestracja { get; set; }

        public string Marka { get; set; }

        public string Model { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int Numer_tel { get; set; }
    }
}
