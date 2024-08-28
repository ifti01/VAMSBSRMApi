using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VAMSBSRMApi.Persistance.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Number { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual VehicleCategory Category { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; } // Assuming a User model exists
        public int? EmployerId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
