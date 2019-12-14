using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace BLL.DtoEntities.ProductDto
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required] 
        public double Price { get; set; }
        
        public  string File { get; set; }
    }
}