using JetShop_CarRent.Modells;
using JetShop_CarRent.Modells.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace JetShop_CarRent.Services
{
    public class ReturnCarService
    {
        private Price price;
        public ReturnCarService()
        {
            price = new Price();
        }

        public void IntializeReturn()
        {
            using (var db = new CarRentalDBContext())
            {
                var resevations = db.Resevations.Where(x => x.Car.IsRented == true).ToList();
                Console.WriteLine("Select Booking number");
                var loop = 1;
                foreach (var item in resevations)
                {
                    Console.WriteLine($"{loop} - {item.BookingNumber}");
                    loop++;
                }
                var listindex = int.Parse(Console.ReadLine());
                var userresv = resevations.ElementAt(listindex-1);
                var car = db.Cars.Find(userresv.CarId);
                var dayspent = (DateTime.Now - userresv.BookingDate).Days;
                //var tempdate = new DateTime(2021,03,13);
                //var dayspent = (DateTime.Now - tempdate).Days;
                Console.WriteLine("What is the current milage on the car? Enter numbers");
                var currentmileage = int.Parse(Console.ReadLine());
                
                var mileage = currentmileage - car.Mileage;
                var rentalcategory = userresv.RentalCategory;
                var cost = CalculateCost(dayspent,mileage,rentalcategory);
                Console.WriteLine($"Total cost of the resevation is {cost}");
                car.Mileage = currentmileage;
                car.IsRented = false;
                db.Update(car);
                db.SaveChanges();
                Console.ReadLine();
            }
        }

        public float CalculateCost(int days, int mileage, RentalCategory category)
        {
            switch (category)
            {
                case RentalCategory.COMPACT:
                    return price.CompactPrice;
                    break;
                case RentalCategory.PREMIUM:
                    price.NumberOfDays = days;
                    price.NumberOfKilometers = mileage;
                    return price.PremiumPrice;
                    break;
                case RentalCategory.MINIVAN:
                    price.NumberOfDays = days;
                    price.NumberOfKilometers = mileage;
                    return price.MinivanPrice;
                    break;
                default:
                    return 0f;
                    break;
            }
        }
    }
}
