using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class Representasi
    {
        [Key]
        public string id { get; set; }
        public string uraian { get; set; }
        public int luarkota { get; set; }
        public int dalamkota { get; set; }


    }
}
