using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services.Interfaces;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        public readonly IBonusPoolService _bonusPoolService;
        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bonusPoolService.GetEmployeesAsync();
            return Ok(response);
        }

        [HttpPost("CalculateBonus")]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _bonusPoolService.CalculateAsync(request.TotalBonusPoolAmount, request.SelectedEmployeeId);
            return Ok(response);
        }
    }
}
