using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MVCApp.Models;

namespace MVCApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MVCApp.Models.Representasi> Representasi { get; set; }
        public DbSet<MVCApp.Models.TiketPesawat> TiketPesawat { get; set; }
        public DbSet<MVCApp.Models.UangHarian> UangHarian { get; set; }
    }
}
