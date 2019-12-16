using BLL.DtoEntities.OrderDto;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Task2_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateOrder(CreateOrderDto orderDto)
        {
            _orderService.CreateOrder(orderDto);
            return Ok();
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult GetOrders()
        {
            return Ok(_orderService.GetOrder());
        }
    }
}