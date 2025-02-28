using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class EvaluationTuteur
    {
        public Guid Id { get; set; }

        // Clé étrangère vers CompteRendu

        public Guid CompteRenduId { get; set; }
        public CompteRendu CompteRendu {  get; set; }

        //Clé étrangère vers Utilisateur (Tuteur)
        public Guid TuteurId { get; set; }
        public Utilisateur Tuteur { get; set; }

        public string Commentaire { get; set; } =string.Empty;
        public Note Note {  get; set; } 
        public DateTime DateEvaluation { get; set; } = DateTime.UtcNow;


    }
}
