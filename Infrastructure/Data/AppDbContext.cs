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

            // Relation Utilisateur → CompteRendus
            modelBuilder.Entity<CompteRendu>()
                .HasOne(c => c.Etudiant)
                .WithMany(u => u.CompteRendus)
                .HasForeignKey(c => c.EtudiantId);

            // Relation EvaluationTuteur → CompteRendu
            modelBuilder.Entity<EvaluationTuteur>()
                .HasOne(e => e.CompteRendu)
                .WithOne()
                .HasForeignKey<EvaluationTuteur>(e => e.CompteRenduId);

            // Relation EvaluationTuteur → Tuteur
            modelBuilder.Entity<EvaluationTuteur>()
                .HasOne(e => e.Tuteur)
                .WithMany()
                .HasForeignKey(e => e.TuteurId);

            // Relation Utilisateur → FicheEtudiant (1:1)
            modelBuilder.Entity<FicheEtudiant>()
                .HasOne(f => f.Etudiant)
                .WithOne()
                .HasForeignKey<FicheEtudiant>(f => f.EtudiantId);
        }
    }
}

