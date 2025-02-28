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

        // Role(Etudiant, Tuteur, Admin)
        public RoleUtulisateur Role {  get; set; }
        //Relation avec les CRA (Un étudiant peut avoir plusieurs CRA)
        public List<CompteRendu> CompteRendus { get; set; } = new();
    }
}
