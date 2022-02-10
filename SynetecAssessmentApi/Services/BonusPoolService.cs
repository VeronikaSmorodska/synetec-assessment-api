using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Domain.Constants;
using SynetecAssessmentApi.Domain.Errors;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using SynetecAssessmentApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public BonusPoolService(IEmployeeRepository employeeRepository)
        {
            // All repository access logic moved to Employee repository class.
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAllWithDepartment();

            List<EmployeeDto> result = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                result.Add(
                    new EmployeeDto
                    {
                        Fullname = employee.Fullname,
                        JobTitle = employee.JobTitle,
                        Salary = employee.Salary,
                        Department = new DepartmentDto
                        {
                            Title = employee.Department.Title,
                            Description = employee.Department.Description
                        }
                    });
            }

            return result;
        }

        public async Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId)
        {
            //load the details of the selected employee using the Id
            Employee employee = await _employeeRepository.GetByIdWithDepartment(selectedEmployeeId);

            if (employee == null)
            {
                var errorString = string.Format(ExceptionConstants.EMPLOYEE_NOT_FOUND, selectedEmployeeId);
                throw new CustomAppError(errorString, System.Net.HttpStatusCode.BadRequest);
            }
            //get the total salary budget for the company
            int totalSalary = (int)await _employeeRepository.GetEmployeesSallarySumAsync();

            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employee.Salary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);

            return new BonusPoolCalculatorResultDto
            {
                Employee = new EmployeeDto
                {
                    Fullname = employee.Fullname,
                    JobTitle = employee.JobTitle,
                    Salary = employee.Salary,
                    Department = new DepartmentDto
                    {
                        Title = employee.Department.Title,
                        Description = employee.Department.Description
                    }
                },

                Amount = bonusAllocation
            };
        }
    }
}
