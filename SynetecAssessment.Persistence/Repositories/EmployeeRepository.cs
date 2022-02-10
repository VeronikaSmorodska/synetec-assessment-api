using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly DbSet<Employee> _dbSet;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<Employee>();
        }

        public async Task<Employee> GetByIdWithDepartment(int selectedEmployeeId)
        {
            return await _dbSet.Include(e => e.Department)
                               .FirstOrDefaultAsync(item => item.Id == selectedEmployeeId);
        }

        public async Task<decimal> GetEmployeesSallarySumAsync()
        {
            return await _dbSet.SumAsync(item => item.Salary);
        }

        public async Task<List<Employee>> GetAllWithDepartment()
        {
            return await _dbSet.Include(e => e.Department)
                               .ToListAsync();
        }
    }
}
