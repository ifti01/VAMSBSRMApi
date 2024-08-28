using System.ComponentModel.DataAnnotations;

namespace VAMSBSRMApi.Application.Dtos
{
    public class CreateVehicleCategoryDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
