using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserRole
    {
        [Required]
        [Key]
        [DisplayName("Id User Role")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [DisplayName("User Id")]
        public string UserId { get; set; }

        [ForeignKey("Role")]
        [DisplayName("Role ID")]
        public string RoleId { get; set; }
    }
}
