using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class UangHarian
    {
        [Key]
        public int Id { get; set; }
        public string provinsi { get; set; }
        public int luarkota { get; set; }
        public int dalamkota { get; set; }
        public int diklat { get; set; }



    }
}
