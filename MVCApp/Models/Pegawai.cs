using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCApp.Models
{
    public class Pegawai
    {
        [Key]
        public int idPegawai { get; set; }
        [DisplayName("Nama Pegawai")]
        public string namePegawai { get; set; }
        [DisplayName("NIP Pegawai")]
        public int nipPegawai { get; set; }
        [DisplayName("Jabatan Pegawai")]
        public string jabatanPegawai { get; set; }
        [DisplayName("Golongan Pegawai")]
        [ForeignKey("Golongan")]
        public int golonganPegawai { get; set; }
    }
}
