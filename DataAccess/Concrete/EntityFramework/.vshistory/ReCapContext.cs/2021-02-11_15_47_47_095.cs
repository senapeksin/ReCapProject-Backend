using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        //OnConfiguring : Projenin hangi veritabanı ile ilişkili olduğunu belirttiğimiz yer.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapDatabase;Trusted_Connection=true");
        }
        //DbSet: Hangi nesne hangi veritabanındaki tabloya karsılık gelecek onu belirtmek için kullanırız.
        public DbSet<Car> Cars { get; set; }
        public Brand Brands { get; set; }
        public Color Colors { get; set; }

    }
}
