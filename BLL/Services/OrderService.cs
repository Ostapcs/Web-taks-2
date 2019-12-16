using System.Collections.Generic;
using System.Linq;
using BLL.DtoEntities.OrderDto;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _db;

        public OrderService(IUnitOfWork db)
        {
            _db = db;
        }
        
        public void CreateOrder(CreateOrderDto orderDto)
        {
            var order = orderDto.ToOrder();
            
            _db.Orders.Add(order);
            _db.Save();

            if (orderDto.ProductIds.Any())
            {
                foreach (var productId in orderDto.ProductIds)
                {
                    var po = new ProductOrders {OrderId = order.Id, ProductId = productId};
                    order.ProductOrders.Add(po);
                }
            }
            
            _db.Orders.Update(order);
            _db.Save();
        }

        public IEnumerable<OrderInfoDto> GetOrder()
        {
            var order = _db.Orders.GetAll();

            return order.Select(o => o.ToOrderInfoDto()).ToList();
        }
    }
}