using System.ComponentModel.DataAnnotations;

namespace SynetecAssessmentApi.Dtos
{
    public class CalculateBonusDto
    {
        [Required]
        public int TotalBonusPoolAmount { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be {1} or greater")]
        public int SelectedEmployeeId { get; set; }
    }
}
