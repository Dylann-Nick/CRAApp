using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<CompteRendu> CompteRendus { get; set; }
        public DbSet<EvaluationTuteur> EvaluationsTuteurs { get; set; }
        public DbSet<FicheEtudiant> FichesEtudiants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Relation Utilisateur - CompteRendu (Un étudiant peut avoir plusieurs comptes-rendus)
            modelBuilder.Entity<CompteRendu>()
                .HasOne(c => c.Etudiant)
                .WithMany(u => u.CompteRendus)
                .HasForeignKey(c => c.EtudiantId)
                .OnDelete(DeleteBehavior.Restrict); // 

            // 🔹 Relation CompteRendu - EvaluationTuteur (Un compte-rendu peut avoir plusieurs évaluations)
            modelBuilder.Entity<EvaluationTuteur>()
                .HasOne(e => e.CompteRendu)
                .WithMany(c => c.EvaluationsTuteurs)
                .HasForeignKey(e => e.CompteRenduId)
                .OnDelete(DeleteBehavior.Restrict); // 

            // 🔹 Correction : Relation EvaluationTuteur - Tuteur (Un tuteur peut avoir plusieurs évaluations)
            modelBuilder.Entity<EvaluationTuteur>()
                .HasOne(e => e.Tuteur)
                .WithMany(u => u.EvaluationsEnTantQueTuteur) // Relation bien définie !
                .HasForeignKey(e => e.TuteurId)
                .OnDelete(DeleteBehavior.Restrict); // 

            // 🔹 Relation Utilisateur - FicheEtudiant (Un étudiant a une seule fiche)
            modelBuilder.Entity<FicheEtudiant>()
                .HasOne(f => f.Etudiant)
                .WithOne(u => u.FicheEtudiant)
                .HasForeignKey<FicheEtudiant>(f => f.EtudiantId)
                .OnDelete(DeleteBehavior.Restrict); 
        }




    }
}

