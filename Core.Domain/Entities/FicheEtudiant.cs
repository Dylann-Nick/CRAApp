using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class FicheEtudiant
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Clé étrangère vers Utilisateur
        public Guid EtudiantId { get; set; }
        public Utilisateur Etudiant { get; set; }

        public string Formation { get; set; } = string.Empty;
        public string Promotion { get; set; } = string.Empty;
    }
}
