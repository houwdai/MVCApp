using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class Pegawai
    {
        public int idPegawai { get; set; }
        [DisplayName("Nama Pegawai")]
        public string namePegawai { get; set; }
        [DisplayName("NIP Pegawai")]
        public int nipPegawai { get; set; }
        [DisplayName("Jabatan Pegawai")]
        public string jabatanPegawai { get; set; }
        [DisplayName("Golongan Pegawai")]
        public string golonganPegawai { get; set; }
    }
}
