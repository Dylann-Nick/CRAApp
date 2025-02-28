using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IEvaluationTuteurRepository
    {
        Task<EvaluationTuteur?> GetByIdAsync(Guid id);
        Task<IEnumerable<EvaluationTuteur>> GetAllByTuteurIdAsync(Guid tuteurId);
        Task<IEnumerable<EvaluationTuteur>> GetAllAsync();
        Task AddAsync(EvaluationTuteur evaluation);
        Task UpdateAsync(EvaluationTuteur evaluation);
        Task DeleteAsync(Guid id);
    
    }
}
