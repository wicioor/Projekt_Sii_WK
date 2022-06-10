using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Entities
{
    public class Klient
    {
        public int Id { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int Numer_tel { get; set; }

        public int PojazdId { get; set; }
        

        public virtual Serwis_samoch Serwis_samoch { get; set; }

    }
}
