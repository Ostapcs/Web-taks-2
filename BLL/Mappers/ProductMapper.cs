using System.Linq;
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

        public static ProductInfo ToProductInfo(this Product product)
        {
            return new ProductInfo
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Rating = product.Rating,
                File = product.File,
                Comments = product.Comments.Select(c => c.ToCommentInfo()).ToList()
            };
        }

        public static ProductCartDto ToProductCartDto(this Product product)
        {
            return new ProductCartDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}