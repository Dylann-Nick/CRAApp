using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IUtilisateurRepository
    {
        Task<Utilisateur?> GetByIdAsync(Guid id);
        Task<Utilisateur?> GetByEmailAsync(string email);
        Task<IEnumerable<Utilisateur>> GetAllAsync();
        Task AddAsync(Utilisateur utilisateur);
        Task UpdateAsync(Utilisateur utilisateur);
        Task DeleteAsync(Guid id);
    
    }
}
