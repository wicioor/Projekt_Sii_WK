using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Entities
{
    public class Serwis_samoch
    {
        //baza danych poświecono numerom zleceń w serwisie samochodowym
        public int Id { get; set; }

        public int Garaz { get; set; }

        public string Pracownik { get; set; }

        public string Rodzaj_wady { get; set; }

        public int PojazdId { get; set; }

        public int KlientId { get; set; }

        
        public virtual Klient Klient { get; set; }
        public virtual  Pojazd Pojazd { get; set; }
    }
}
