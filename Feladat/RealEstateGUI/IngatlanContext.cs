using Microsoft.EntityFrameworkCore;
using RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateGUI
{
    class IngatlanContext : DbContext
    {
        public DbSet<Ad> RealEstates { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;database=ingatlan;uid=root;pwd=;", ServerVersion.AutoDetect("Server=localhost;database=ingatlan;uid=root;pwd=;"));
        }

    }
}
