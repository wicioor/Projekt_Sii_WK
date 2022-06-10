using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_Sii_WK.Entities
{
    
    public class SerwisDbContext : DbContext 
    {
        //wykorzystujac adres (localdb)\mssqllocaldb mozna polaczyc sie z bazą
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=SerwisDb;Trusted_Connection=True;";


        //Dbset pozwala na utworzenie tabeli
        public DbSet<Serwis_samoch> Serwis { get; set; }

        public DbSet<Pojazd> Pojazdy { get; set; }

        public DbSet<Klient> Klienci { get; set; }

        //override poniewaz przywolano metodę z tabeli bazowej DbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modyfikowanie zawartości tabeli
            modelBuilder.Entity<Serwis_samoch>()
                .Property(s => s.Garaz)
                .IsRequired();

            modelBuilder.Entity<Serwis_samoch>()
                .Property(s => s.Pracownik)
                .IsRequired();

            modelBuilder.Entity<Pojazd>()
                .Property(p => p.Rejestracja)
                .IsRequired()
                .HasMaxLength(7);

            modelBuilder.Entity<Klient>()
                .Property(k => k.Numer_tel)
                .IsRequired()
                .HasMaxLength(9);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(_connectionString);

            
        }
    }
}
