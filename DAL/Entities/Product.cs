using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double  Rating { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<ProductOrders> ProductOrders { get; set; }

        public Product()
        {
            Comments = new HashSet<Comment>();
            ProductOrders = new HashSet<ProductOrders>();
        }

    }
}
