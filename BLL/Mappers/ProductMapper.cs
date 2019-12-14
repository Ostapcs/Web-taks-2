using BLL.DtoEntities.ProductDto;
using DAL.Entities;

namespace BLL.Mappers
{
    public static class ProductMapper
    {
        public static Product ToProduct(this CreateProductDto createProductDto)
        {
            return new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                File = createProductDto.File
            };
        }
    }
}