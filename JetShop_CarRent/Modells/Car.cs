using System;
using System.Collections.Generic;
using System.Text;

namespace JetShop_CarRent.Modells
{
    public class Car
    {
        public Guid Id { get; private set; }
        public bool IsRented { get; set; }
        public int Mileage { get; set; }
        public string CarModel { get; set; }
        public Car()
        {
            Id = Guid.NewGuid();
        }
    }
}
