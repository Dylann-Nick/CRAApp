using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class CompteRenduRepository: ICompteRenduRepository
    {

        private readonly AppDbContext _context;

        public CompteRenduRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompteRendu?> GetByIdAsync(Guid id) =>
            await _context.CompteRendus.FindAsync(id);

        public async Task<IEnumerable<CompteRendu>> GetAllByEtudiantIdAsync(Guid etudiantId) =>
            await _context.CompteRendus.Where(c => c.EtudiantId == etudiantId).ToListAsync();

        public async Task<IEnumerable<CompteRendu>> GetAllAsync() =>
            await _context.CompteRendus.ToListAsync();

        public async Task AddAsync(CompteRendu compteRendu)
        {
            await _context.CompteRendus.AddAsync(compteRendu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompteRendu compteRendu)
        {
            _context.CompteRendus.Update(compteRendu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var compteRendu = await GetByIdAsync(id);
            if (compteRendu != null)
            {
                _context.CompteRendus.Remove(compteRendu);
                await _context.SaveChangesAsync();
            }
        }
    }
}

