using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext shopContext) : base(shopContext)
        {
            
        }
    }
}
