using Projekt_Sii_WK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Sii_WK
{//wykorzystanie SEEDERA wymusza wywolanie w klasie STARTUP
    public class SerwisSeeder
    {
        private readonly SerwisDbContext _dbContext;
        public SerwisSeeder(SerwisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public void Seed()
        {
            
            if(_dbContext.Database.CanConnect())
            {
                
                if (!_dbContext.Serwis.Any())
                {
                    
                    var serwis = GetSerwis();
                    _dbContext.Serwis.AddRange(serwis);
                    
                    _dbContext.SaveChanges();
                } 
            }
        }
        
        private IEnumerable<Serwis_samoch>GetSerwis()
        {
            var serwis = new List<Serwis_samoch>
            {
                new Serwis_samoch()
                {
                    Garaz = 1,
                    Pracownik = "Marcin",
                    Rodzaj_wady = "Serwis_olejowy",
                    Klient = new Klient()
                    {
                        Imie = "Wiesław",
                        Nazwisko = "Paleta",
                        Numer_tel = 546786543,
                    },
                    Pojazd = new Pojazd()
                    {
                        Rejestracja = "P0 WD40",
                        Model = "VW",
                        Marka = "Passat"
                    }
                },
                new Serwis_samoch()
                {
                    Garaz = 2,
                    Pracownik = "Maricn",
                    Rodzaj_wady = "urwany_tylni_wozek",
                    Klient = new Klient()
                    {
                        Imie = "Sebastian",
                        Nazwisko = "Przecietny",
                        Numer_tel = 546786532,
                    },
                    Pojazd = new Pojazd()
                    {
                        Rejestracja = "PZ PDW7",
                        Model = "BMW",
                        Marka = "E46"
                    }
                },
                new Serwis_samoch()
                {
                    Garaz = 2,
                    Pracownik = "Cezary",
                    Rodzaj_wady = "swap 3.2 FSI",
                    Klient = new Klient()
                    {
                        Imie = "Kacper",
                        Nazwisko = "Bagins",
                        Numer_tel = 546778543,
                    },
                    Pojazd = new Pojazd()
                    {
                        Rejestracja = "WE 2137",
                        Model = "Audi",
                        Marka = "A4"
                    }
                },
                new Serwis_samoch()
                {
                    Garaz = 1,
                    Pracownik = "Stefan",
                    Rodzaj_wady = "wymiana żarówek",
                    Klient = new Klient()
                    {
                        Imie = "Katarzyna",
                        Nazwisko = "Kowalska",
                        Numer_tel = 668786532,
                    },
                    Pojazd = new Pojazd()
                    {
                        Rejestracja = "EL 5463",
                        Model = "AMG",
                        Marka = "A45S"
                    }
                },
            };

            return serwis;
        }
    }
}
