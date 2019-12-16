using System.Linq;
using BLL.DtoEntities.OrderDto;
using DAL.Entities;

namespace BLL.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrder(this CreateOrderDto orderDto)
        {
            return new Order
            {
                Price = orderDto.Price,
                DeliveryOpt = orderDto.DeliveryOpt,
                UserId = orderDto.UserId
            };
        }

        public static OrderInfoDto ToOrderInfoDto(this Order order)
        {
            return new OrderInfoDto
            {
                Id = order.Id,
                DeliveryOpt = order.DeliveryOpt,
                Price = order.Price,
                UserInfoDto = order.User.ToUserInfo(),
                ProductDtos = order.ProductOrders.Select(p => p.Product.ToProductCartDto()).ToList()
            };
        }
    }
}