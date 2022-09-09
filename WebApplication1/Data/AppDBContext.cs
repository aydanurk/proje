using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }

    }
}
