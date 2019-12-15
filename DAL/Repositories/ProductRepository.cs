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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext shopContext) : base(shopContext) 
        {
        }

        public new Product GetById(int id)
        {
            return dbContext.Products
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
