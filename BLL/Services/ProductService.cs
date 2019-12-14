using BLL.DtoEntities.ProductDto;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _db;

        public ProductService(IUnitOfWork db)
        {
            _db = db;
        }

        public void CreateProduct(CreateProductDto productDto)
        {
            var product = productDto.ToProduct();
            
            _db.Products.Add(product);
            _db.Save();
        }
    }
}