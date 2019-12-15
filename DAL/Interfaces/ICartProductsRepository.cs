using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ICartProductsRepository : IRepository<CartProducts>
    {
        IEnumerable<CartProducts> GetUsersCart(int userId);
        CartProducts GetById(int userId, int productId);
    }
    
}