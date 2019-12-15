using BLL.DtoEntities;
using BLL.DtoEntities.CartDto;
using BLL.DtoEntities.ProductDto;
using DAL.Entities;

namespace BLL.Mappers
{
    public static class CartMapper
    {
        public static CartProducts ToCart(this CartDto cartDto)
        {
            return new CartProducts
            {
                UserId = cartDto.UserId,
                ProductId = cartDto.ProductId,
                Amount = cartDto.Amount
            };
        }

        public static CartInfoDto ToCartInfo(this CartProducts cart)
        {
            return new CartInfoDto
            {
                product = new ProductCartDto
                {
                    Id = cart.Product.Id,
                    Name = cart.Product.Name,
                    Price = cart.Product.Price
                },
                Amount = cart.Amount
            };
        }
        
    }
}