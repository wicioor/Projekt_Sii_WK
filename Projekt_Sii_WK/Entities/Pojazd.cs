using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK.Entities
{
    public class Pojazd
    {
        public int Id { get; set; }

        public string Rejestracja { get; set; }

        public string Marka { get; set; }

        public string Model { get; set; }

        public virtual Serwis_samoch Serwis_samoch { get; set; }

    }
}
