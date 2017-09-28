using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerJQX.Models
{
    public class Customer
    {
        public int CustomerId { get ; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
    //    public string PhoneNo { get; set; }
        public string City { get; set; }
   //     public string District { get; set; }
        public string State { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}