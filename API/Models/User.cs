using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {

        [Key]
        public Staff Staff { get; set; }
        [ForeignKey("Staff")]
        [DisplayName("ID User")]
        public int Id { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
