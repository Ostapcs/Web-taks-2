using System.Collections.Generic;
using BLL.DtoEntities.ProductDto;
using BLL.DtoEntities.UserDto;

namespace BLL.DtoEntities.OrderDto
{
    public class OrderInfoDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string DeliveryOpt { get; set; }

        public UserInfoDto UserInfoDto { get; set; }

        public List<ProductCartDto> ProductDtos { get; set; } = new List<ProductCartDto>();
        
    }
}