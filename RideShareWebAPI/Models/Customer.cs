using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideShareWebAPI.Models
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(string e, string p, string n, string ph, double xc, double yc)
        {
            this.Email = e;
            this.Password = p;
            this.Name = n;
            this.PhoneNo = ph;
            this.XCoordinate = xc;
            this.YCoordinate = yc;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string CreditCardNo { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
    }
}