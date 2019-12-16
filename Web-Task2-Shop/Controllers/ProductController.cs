using System.IO;
using BLL.DtoEntities.ProductDto;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Task2_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost]
        [Route("create")]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.CreateProduct(createProductDto);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateProduct(UpdateProductDto productDto)
        {
            _productService.UpdateProduct(productDto);

            return Ok();
        }

        [HttpGet]
        [Route("info/{id}")]
        public IActionResult GetProductInfo(int id)
        {
            return Ok(_productService.GetProductInfo(id));
        }
        
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAll());
        }
        
        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult RemoveProduct(int id)
        {
            _productService.RemoveProduct(id);
            return Ok();
        }
    }
}