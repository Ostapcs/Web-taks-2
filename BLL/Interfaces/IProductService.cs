using System.Collections.Generic;
using BLL.DtoEntities.ProductDto;
using BLL.DtoEntities.UserDto;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(CreateProductDto productDto);

        UpdateProductDto UpdateProduct(UpdateProductDto productDto);

        ProductInfo GetProductInfo(int id);

        void RemoveProduct(int id);

        IEnumerable<ProductInfo> GetAll();
    }
}