using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext shopContext) : base(shopContext) 
        {
            
        }
    }
}
