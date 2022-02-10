using SynetecAssessmentApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity model);
        Task DeleteAsync(TEntity model);
        Task SaveChangesAsync();
        Task UpdateAsync(TEntity model);
    }
}
