using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPartsInventory.cs.Models
{
    public class Order
    {
        public List<OrderItem> OrderItemsList { get; set; }

        public Order()
        {
            OrderItemsList = new List<OrderItem>();
        }
    }
}