using System.ComponentModel.DataAnnotations;

namespace VAMSBSRMApi.Persistance.Models
{
    public class VehicleCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // Navigation property for the vehicles in this category
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}

