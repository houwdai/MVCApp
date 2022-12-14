using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Context
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {
        }
        public DbSet<Pegawai> Pegawaii { get; set; }
        public DbSet<Golongan> Golongans { get; set; }

        public DbSet<TiketPesawat> TiketPesawat { get; set; }
        public DbSet<UangHarian> UangHarian { get; set; }
        public DbSet<Representasi> Represtasis { get; set; }

        public DbSet<Admin> Admin { get; set; }

    }
}
