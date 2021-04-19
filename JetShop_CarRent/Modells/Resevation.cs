using JetShop_CarRent.Modells.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetShop_CarRent.Modells
{
    public class Resevation
    {
        public Guid Id { get; private set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public RentalCategory RentalCategory { get; set; }
        public int BookingNumber { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
        //public DateTime
        public Resevation()
        {
            Id = Guid.NewGuid();
        }
    }
}
