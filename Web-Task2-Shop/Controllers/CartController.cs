using BLL.DtoEntities.CartDto;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Task2_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddToCart(CartDto cart)
        {
            _cartService.AddToCart(cart);
            return Ok();
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetCart(int userId)
        {
            return Ok(_cartService.GetCartInfo(userId));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateAmount(CartDto cart)
        {
            _cartService.UpdateAmount(cart);
            return Ok();
        }
    }
}