using System.Collections.Generic;

namespace BLL.DtoEntities.OrderDto
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public double Price { get; set; }
        public string DeliveryOpt { get; set; }
        public IEnumerable<int> ProductIds { get; set; }

        public CreateOrderDto()
        {
            ProductIds = new HashSet<int>();
        }
    }
}