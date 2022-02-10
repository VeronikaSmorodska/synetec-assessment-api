using SynetecAssessmentApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdWithDepartment(int selectedEmployeeId);
        Task<decimal> GetEmployeesSallarySumAsync();
        Task<List<Employee>> GetAllWithDepartment();
    }
}
