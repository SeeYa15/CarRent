using JetShop_CarRent.Modells;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JetShop_CarRent
{
    public class CarRentalDBContext : DbContext
    {
        //private const string connectionString = "Server=(Localdb)\\mssqllocaldb;Database=CarRentalDB;Trusted_Connection=True;";
        private const string connectionString = "Server=Johnny-WORK\\SQLEXPRESS;Database=CarRentalDB;Trusted_Connection=True;";
        private List<Car> cars;
        public CarRentalDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Createseed();
            modelBuilder.Entity<Car>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Resevation>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Car>().HasData(cars);
        }

        private void Createseed()
        {
            cars = new List<Car>
            {
                new Car { CarModel ="Volvo 740", IsRented=false, Mileage=27000, },
                new Car { CarModel ="Volvo V60", IsRented=false, Mileage=10300, },
                new Car { CarModel ="Audi TT", IsRented=false, Mileage=5600, },
                new Car { CarModel ="Audi Q4", IsRented=false, Mileage=5123, },
                new Car { CarModel ="Toyota Yaris", IsRented=false, Mileage=12551, },
                new Car { CarModel ="Toyota Rav4", IsRented=false, Mileage=125345, },
                new Car { CarModel ="Volvo V40", IsRented=false, Mileage=23561, },
                new Car { CarModel ="Dodge Charger", IsRented=false, Mileage=3451, },
                new Car { CarModel ="Lamborghini Gallardo", IsRented=false, Mileage=8123 },
            };
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Resevation> Resevations { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
