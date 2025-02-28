using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FicheEtudiantRepository: IFicheEtudiantRepository
    {
        private readonly AppDbContext _context;

        public FicheEtudiantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FicheEtudiant?> GetByEtudiantIdAsync(Guid etudiantId) =>
            await _context.FichesEtudiants.SingleOrDefaultAsync(f => f.EtudiantId == etudiantId);

        public async Task<IEnumerable<FicheEtudiant>> GetAllAsync() =>
            await _context.FichesEtudiants.ToListAsync();

        public async Task AddAsync(FicheEtudiant fiche)
        {
            await _context.FichesEtudiants.AddAsync(fiche);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FicheEtudiant fiche)
        {
            _context.FichesEtudiants.Update(fiche);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var fiche = await _context.FichesEtudiants.FindAsync(id);
            if (fiche != null)
            {
                _context.FichesEtudiants.Remove(fiche);
                await _context.SaveChangesAsync();
            }
        }
    }
}
