using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UtilisateurRepository: IUtilisateurRepository
    {
        private readonly AppDbContext _context;

        public UtilisateurRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Utilisateur?> GetByIdAsync(Guid id) =>
            await _context.Utilisateurs.FindAsync(id);

        public async Task<Utilisateur?> GetByEmailAsync(string email) =>
            await _context.Utilisateurs.SingleOrDefaultAsync(u => u.Email == email);

        public async Task<IEnumerable<Utilisateur>> GetAllAsync() =>
            await _context.Utilisateurs.ToListAsync();

        public async Task AddAsync(Utilisateur utilisateur)
        {
            await _context.Utilisateurs.AddAsync(utilisateur);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Update(utilisateur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var utilisateur = await GetByIdAsync(id);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
