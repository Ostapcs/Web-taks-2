using System.Collections.Generic;
using System.Linq;
using BLL.DtoEntities;
using BLL.DtoEntities.CartDto;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _db;

        public CartService(IUnitOfWork db)
        {
            _db = db;
        }


        public void AddToCart(CartDto cartDto)
        {
            var cart = cartDto.ToCart();
            
            _db.CartProducts.Add(cart);
            _db.Save();
        }

        public IEnumerable<CartInfoDto> GetCartInfo(int userId)
        {
            var cart = _db.CartProducts.GetUsersCart(userId);

            return cart.Select(c => c.ToCartInfo()).ToList();
        }

        public void UpdateAmount(CartDto cartDto)
        {
            var cart = _db.CartProducts.GetById(cartDto.UserId, cartDto.ProductId);

            cart.Amount = cartDto.Amount;
            _db.CartProducts.Update(cart);
            _db.Save();
        }

        public void RemoveFromCart(CartDto cartDto)
        {
            throw new System.NotImplementedException();
        }
    }
}