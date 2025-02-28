using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class CompteRendu
    {
        public Guid Id { get; set; }

        //Clé étrangère vers l'utilisateur (etudiant)
        public Guid EtudiantId { get; set; }
        public Utilisateur Etudiant { get; set; }
        public string Mission {  get; set; }
        public string EtapesRealisation {  get; set; }
        public bool TravailEntreprise {  get; set; }
        public string Difficultes { get; set; }
        public string CompetanceMisesEnOeuvre {  get; set; }
        
        //Retour du tuteur (optionnel)
        public string? RetourTuteur {  get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        //Ajout de la collection d'évaluations
        public ICollection<EvaluationTuteur> EvaluationsTuteurs { get; set; } = new List<EvaluationTuteur>();
    }
}
