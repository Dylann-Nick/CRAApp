using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface ICompteRenduRepository
    {
        Task<CompteRendu?> GetByIdAsync(Guid id);
        Task<IEnumerable<CompteRendu>> GetAllByEtudiantIdAsync(Guid etudiantId);
        Task<IEnumerable<CompteRendu>> GetAllAsync();
        Task AddAsync(CompteRendu compteRendu);
        Task UpdateAsync(CompteRendu compteRendu);
        Task DeleteAsync(Guid id);
    }
}
