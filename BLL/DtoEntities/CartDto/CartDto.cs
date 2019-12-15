using System.ComponentModel.DataAnnotations;

namespace BLL.DtoEntities.CartDto
{
    public class CartDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}