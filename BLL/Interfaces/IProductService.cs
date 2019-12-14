using BLL.DtoEntities.ProductDto;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(CreateProductDto productDto);
    }
}