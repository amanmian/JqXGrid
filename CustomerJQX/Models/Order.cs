using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerJQX.Models
{
    public class Order
    {
        public Order()
        {
            List<Product> ProductList = new List<Product>();
        }
        public int OrderId { get; set; }
        public string OrderedItem { get; set; }
        public int OrderedQuantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}