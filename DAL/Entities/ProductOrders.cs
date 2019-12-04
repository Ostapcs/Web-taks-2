using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProductOrders
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
