using SynetecAssessmentApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdWithDepartment(int selectedEmployeeId);
        int GetEmployeesSallarySum();
        Task<List<Employee>> GetAllWithDepartment();
    }
}
