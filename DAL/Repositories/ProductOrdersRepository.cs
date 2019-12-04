using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProductOrdersRepository : Repository<ProductOrders>, IProductOrdersRepository
    {
        public ProductOrdersRepository(ShopContext shopContext) : base(shopContext)
        {
            
        }
    }
}
