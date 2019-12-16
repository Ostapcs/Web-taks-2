using System.Collections.Generic;
using BLL.DtoEntities.OrderDto;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderDto orderDto);

        IEnumerable<OrderInfoDto> GetOrder();
    }
}