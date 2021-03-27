using Core.Entites.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class RentACarContext:DbContext
    {   //Veritabanındaki tablolar ile Kendi classlarımızın arasında ilişkiyi kuruyoruz
        //DbContext: Db tabloları ile proje classlarını bağlamak
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//Connection string case insensitive
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=RentACar;Trusted_Connection=true");           
        }
        //Herbir kullanılacak tablo için yapılmalıdır (prop) ///public DbSet<Class> Db table { get; set; }///
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }


    }
}
