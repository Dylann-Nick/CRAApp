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
    public class EvaluationTuteurRepository: IEvaluationTuteurRepository
    {
        private readonly AppDbContext _context;

        public EvaluationTuteurRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluationTuteur?> GetByIdAsync(Guid id) =>
            await _context.EvaluationsTuteurs.FindAsync(id);

        public async Task<IEnumerable<EvaluationTuteur>> GetAllByTuteurIdAsync(Guid tuteurId) =>
            await _context.EvaluationsTuteurs
                .Where(e => e.TuteurId == tuteurId)
                .ToListAsync();

        public async Task<IEnumerable<EvaluationTuteur>> GetAllAsync() =>
            await _context.EvaluationsTuteurs.ToListAsync();

        public async Task AddAsync(EvaluationTuteur evaluation)
        {
            await _context.EvaluationsTuteurs.AddAsync(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EvaluationTuteur evaluation)
        {
            _context.EvaluationsTuteurs.Update(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var evaluation = await GetByIdAsync(id);
            if (evaluation != null)
            {
                _context.EvaluationsTuteurs.Remove(evaluation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
