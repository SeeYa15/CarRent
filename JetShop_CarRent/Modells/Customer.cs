using System;
using System.Collections.Generic;
using System.Text;

namespace JetShop_CarRent.Modells
{
    public class Customer
    {
        public string SocialSercurityNumber { get; set; }
        public Guid Id { get; private set; }
        public Customer()
        {
            Id = Guid.NewGuid();
        }
    }
}
