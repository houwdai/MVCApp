using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Employee
    {

        [Key]
        [ForeignKey("User")]
        [DisplayName("ID Employee")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nama Lengkap")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
