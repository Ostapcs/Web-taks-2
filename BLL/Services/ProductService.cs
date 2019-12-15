using System.Collections.Generic;
using System.Linq;
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

        public ProductInfo GetProductInfo(int id)
        {
            var product = _db.Products.GetById(id);

            return product.ToProductInfo();
        }

        public UpdateProductDto UpdateProduct(UpdateProductDto productDto)
        {
            var product = _db.Products.GetById(productDto.Id);

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.File = productDto.File;
            product.Rating = productDto.Rating;
            product.Price = productDto.Price;
            
            _db.Products.Update(product);
            _db.Save();

            return productDto;
        }

        public void RemoveProduct(int id)
        {
            var product = _db.Products.GetById(id);
            
            _db.Products.Remove(product);
            _db.Save();
        }

        public IEnumerable<ProductInfo> GetAll()
        {
            return _db.Products
                .GetAll()
                .Select(p => p.ToProductInfo())
                .ToList();
        }
    }
}