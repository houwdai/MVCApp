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

        public User User { get; set; }
        [ForeignKey("User")]
        [DisplayName("User Id")]
        public string UserId { get; set; }


        public Role Role { get; set; }  
        [ForeignKey("Role")]
        [DisplayName("Role ID")]
        public string RoleId { get; set; }
    }
}
