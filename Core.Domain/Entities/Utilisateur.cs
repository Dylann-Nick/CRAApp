using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Utilisateur
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nom { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MotDePasse { get; set; } = string.Empty;
        public RoleUtilisateur Role {  get; set; }
        //Relation avec `CompteRendus` (1 étudiant → plusieurs comptes-rendus)
        public ICollection<CompteRendu> CompteRendus { get; set; } = new List<CompteRendu>();

        //Relation avec `FicheEtudiant` (1 étudiant → 1 seule fiche)
        public FicheEtudiant? FicheEtudiant { get; set; }

        //Relation avec `EvaluationTuteur` (Un tuteur peut faire plusieurs évaluations)
        public ICollection<EvaluationTuteur> EvaluationsTuteurs { get; set; } = new List<EvaluationTuteur>();
        public ICollection<EvaluationTuteur> EvaluationsEnTantQueTuteur { get; set; } = new List<EvaluationTuteur>();

    }
}
