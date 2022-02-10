using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Employee> GetByIdWithDepartment(int selectedEmployeeId)
        {
            return await _dbContext.Employees.Include(e => e.Department)
                                       .FirstOrDefaultAsync(item => item.Id == selectedEmployeeId);
        }

        public int GetEmployeesSallarySum()
        {
            return _dbContext.Employees.Sum(item => item.Salary);
        }

        public async Task<List<Employee>> GetAllWithDepartment()
        {
            return await _dbContext.Employees.Include(e => e.Department)
                                       .ToListAsync();
        }
    }
}
