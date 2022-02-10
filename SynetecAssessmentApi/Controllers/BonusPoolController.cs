using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        public readonly IBonusPoolService _bonusPoolService;
        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            // Using DI instead of creating an instance of BonusPoolService each time we need to use it.
            _bonusPoolService = bonusPoolService;
        }

        // Providing controller actions with distinct names
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bonusPoolService.GetEmployeesAsync();
            return Ok(response);
        }

        // Providing controller actions with distinct names
        [HttpPost("CalculateBonus")]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            // Validating ModelState before sending values further so we might catch some important errors earlier. 
            if (!ModelState.IsValid)
            {
                string errorsString = string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                return BadRequest(errorsString);
            }
            var response = await _bonusPoolService.CalculateAsync(request.TotalBonusPoolAmount, request.SelectedEmployeeId);
            return Ok(response);
        }
    }
}
