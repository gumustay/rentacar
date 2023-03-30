using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentacarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=rentacar_db; user=root; password=''; Persist Security Info=False; Connect Timeout=300;SSL Mode=None");
            
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Color> Colors { get; set; }

    }
}
