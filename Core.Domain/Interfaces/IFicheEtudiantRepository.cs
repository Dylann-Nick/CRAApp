using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IFicheEtudiantRepository
    {
        Task<FicheEtudiant?> GetByEtudiantIdAsync(Guid etudiantId);
        Task<IEnumerable<FicheEtudiant>> GetAllAsync();
        Task AddAsync(FicheEtudiant fiche);
        Task UpdateAsync(FicheEtudiant fiche);
        Task DeleteAsync(Guid id);
    }
}
