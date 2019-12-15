using BLL.DtoEntities.ProductDto;

namespace BLL.DtoEntities.CartDto
{
    public class CartInfoDto
    {
        public ProductCartDto product { get; set; }
        public int Amount { get; set; }
    }
}