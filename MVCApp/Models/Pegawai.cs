using System;
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

        public Golongan Golongan { get; set; }
        [ForeignKey("Golongan")]
        public int IdGolongan { get; set; }

        internal object Include(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
