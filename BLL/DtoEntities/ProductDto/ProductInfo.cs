using System.Collections.Generic;
using BLL.DtoEntities.CommentDto;

namespace BLL.DtoEntities.ProductDto
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double  Rating { get; set; }

        public string File { get; set; }
        public IEnumerable<CommentInfoDto> Comments { get; set; }
    }
}