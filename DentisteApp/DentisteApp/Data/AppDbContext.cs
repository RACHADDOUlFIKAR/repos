using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GestionBudget.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Ordonnance> Ordonnances { get; set; }
        public DbSet<Imagerie> Imageries { get; set; }
        public DbSet<FeuilleDeSoin> FeuillesDeSoin { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Acte> Actes { get; set; }
        public DbSet<Rendez_vous> Rendez_vous { get; set; }
        public DbSet<CertificatMedical> CertificatsMedicaux { get; set; }

    }
}