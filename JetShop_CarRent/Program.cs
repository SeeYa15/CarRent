using JetShop_CarRent.Services;
using System.Linq;
using System;
using JetShop_CarRent.Modells.Enums;

namespace JetShop_CarRent
{
    public class Program
    {
        private static RentalCarService rentalCarService;
        private static ReturnCarService returnCarService;
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, Do you want to rent or return a car? \r\nPress 1 for rent or 0 for returning and enter");
            var rent = int.Parse(Console.ReadLine());

            if (Convert.ToBoolean(rent))
            {
                rentalCarService = new RentalCarService();
                rentalCarService.InitializeRent();
            }
            else
            {
                returnCarService = new ReturnCarService();
                returnCarService.IntializeReturn();
            }


        }
    }
}
