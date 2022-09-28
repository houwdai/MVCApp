using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API.Models
{
    public class Role
    {

        [Key]
        [DisplayName("ID Role")]
        public int Id { get; set; }

        [DisplayName("Name Role")]
        public string Name { get; set; }
    }
}
