using System;
using System.Collections.Generic;
using System.Text;

namespace JetShop_CarRent.Modells
{
    public class Price
    {        
        public int BaseDayRental { get; set; }
        public int KiloMeterPrice { get; set; }
        public int NumberOfDays { get; set; }
        public int NumberOfKilometers { get; set; }

        public int CompactPrice { get { return BaseDayRental * NumberOfDays; } private set { } }
        public float PremiumPrice { get { return BaseDayRental * NumberOfDays * 1.2f + KiloMeterPrice + NumberOfKilometers; } set { } }
        public float MinivanPrice { get { return BaseDayRental * NumberOfDays * 1.7f + (KiloMeterPrice * NumberOfKilometers * 1.5f); } set { } }
        public Price()
        {
            BaseDayRental =70;
            KiloMeterPrice = 5;
        }
    }
}
