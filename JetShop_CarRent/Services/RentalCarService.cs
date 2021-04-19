using JetShop_CarRent.Modells;
using JetShop_CarRent.Modells.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace JetShop_CarRent.Services
{
    public class RentalCarService
    {
        string[] categories = Enum.GetNames(typeof(RentalCategory));
        Random random = new Random();
        public RentalCarService()
        {

        }

        public void RentCar(Car car, RentalCategory category, string socialsecuritynumber, CarRentalDBContext db)
        {
            var resevation = new Resevation();
            var customer = new Customer();
            resevation.CarId = car.Id;
            resevation.Car = car;
            resevation.RentalCategory = category;
            resevation.BookingNumber = random.Next(1, 999999);
            resevation.CustomerId = customer.Id;
            resevation.BookingDate = DateTime.Now;
            customer.SocialSercurityNumber = socialsecuritynumber;
            car.IsRented = true;
            db.Update(car);
            db.Add(customer);
            db.Add(resevation);
            db.SaveChanges();
            Console.WriteLine($"You have rented the car with booking number {resevation.BookingNumber}");
        }
        public void InitializeRent()
        {
            using (var db = new CarRentalDBContext())
            {
                var cars = db.Cars.Where(x => x.IsRented == false).ToList();
                Console.WriteLine("Select one of the available cars by writting the modelname");
                var loop = 1;
                foreach (var item in cars)
                {
                    Console.WriteLine($"{loop} - {item.CarModel}");
                    loop++;
                }
                var result = Console.ReadLine();
                Console.WriteLine("And what type of Category?");
                foreach (var item in categories)
                {
                    Console.WriteLine($"{item}");
                }
                var category = Console.ReadLine().ToUpper();
                Console.WriteLine("Please enter your date of birth with 10 letters");
                var customernumber = Console.ReadLine();
                var selectedcar = db.Cars.Single(x => x.CarModel.ToLower().Contains(result.ToLower()));
                RentCar(selectedcar, Enum.Parse<RentalCategory>(category), customernumber, db);                
                Console.ReadLine();
            }
        }
    }
}
