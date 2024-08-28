using System.ComponentModel.DataAnnotations;

namespace VAMSBSRMApi.Persistance.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string RoleName { get; set; }
    }
}
