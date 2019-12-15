using System.Collections.Generic;
using BLL.DtoEntities;
using BLL.DtoEntities.CartDto;

namespace BLL.Interfaces
{
    public interface ICartService
    {
        void AddToCart(CartDto cartDto);

        IEnumerable<CartInfoDto> GetCartInfo(int userId);

        void UpdateAmount(CartDto cartDto);

        void RemoveFromCart(CartDto cartDto);
    }
}