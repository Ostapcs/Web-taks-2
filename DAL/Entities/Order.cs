using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public string DeliveryOpt { get; set; }
        
        public User User { get; set; }

        public ICollection<ProductOrders> ProductOrders { get; set; }

        public Order()
        {
            ProductOrders = new HashSet<ProductOrders>();
        }
    }
}
