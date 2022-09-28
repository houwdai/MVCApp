using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API.Models
{
    public class User
    {

        [Key]
        [DisplayName("ID User")]
        public int Id { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
