using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using SynetecAssessmentApi.Services;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Tests
{
    [TestClass]
    public class BonusPoolTests
    {
        [TestMethod]
        public async Task BonusCalculationsTest()
        {
            var requestModel = new CalculateBonusDto { TotalBonusPoolAmount = 100, SelectedEmployeeId = 1 };

            var employee = new Employee(1, "Jane Green", "Accountant (Senior)", 15000, 1)
            {
                Department = new Department(1, "Finance", "The finance department for the company")
            };

            var salaryTotal = 100000M;
            var correcResult = 15M;
            var _employeeRepository = new Mock<IEmployeeRepository>();
            _employeeRepository.Setup(x => x.GetByIdWithDepartment(requestModel.SelectedEmployeeId)).Returns(Task.FromResult(employee));
            _employeeRepository.Setup(x => x.GetEmployeesSallarySumAsync()).Returns(Task.FromResult(salaryTotal));

            var financeService = new BonusPoolService(_employeeRepository.Object);
            var result = await financeService.CalculateAsync(requestModel.TotalBonusPoolAmount, requestModel.SelectedEmployeeId);

            Assert.AreEqual(result.Amount, correcResult);
        }
    }
}