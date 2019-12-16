using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext shopContext) : base(shopContext)
        {
            
        }


        public new IEnumerable<Order> GetAll()
        {
            return dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.ProductOrders)
                .ThenInclude(p => p.Product)
                .ToList();
        }
    }
}
