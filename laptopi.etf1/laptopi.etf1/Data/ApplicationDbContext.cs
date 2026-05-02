using laptopi.etf1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace laptopi.etf1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdminModerator> AdminModerator { get; set; }
        public DbSet<Artikal> Artikal { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<Primjedba> Primjedba { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<SlikaArtikla> SlikaArtikla { get; set; }
        public DbSet<Transakcija> Transakcija { get; set; }
        public DbSet<ZahtjevZaUklanjanje> ZahtjevZaUklanjanje { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminModerator>().ToTable("AdminModerator");
            modelBuilder.Entity<Artikal>().ToTable("Artikal");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Ocjena>().ToTable("Ocjena");
            modelBuilder.Entity<Primjedba>().ToTable("Primjedba");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacija");
            modelBuilder.Entity<SlikaArtikla>().ToTable("SlikaArtikla");
            modelBuilder.Entity<Transakcija>().ToTable("Tranakcija");
            modelBuilder.Entity<ZahtjevZaUklanjanje>().ToTable("ZahtjevZaUklanjanje");

            base.OnModelCreating(modelBuilder);
        }
    }
}
