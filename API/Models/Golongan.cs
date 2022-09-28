using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Golongan
    {
        [Key]
        public int IdGolongan { get; set; }

        public string NamaGolongan { get; set; }
    }
}
