using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CartProductsRepository : Repository<CartProducts>, ICartProductsRepository
    {
        public CartProductsRepository(ShopContext shopContext) : base(shopContext)
        {
        }

        public CartProducts GetById(int userId, int productId)
        {
            return dbContext.CartProducts
                .Find(userId, productId);
        }

        public new IEnumerable<CartProducts> GetUsersCart(int userId)
        {
            return dbContext.CartProducts
                .Include(p => p.Product)
                .Where(c => c.UserId == userId)
                .ToList();
        }
    }
}