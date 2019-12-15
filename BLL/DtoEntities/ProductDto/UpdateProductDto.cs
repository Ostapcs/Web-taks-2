namespace BLL.DtoEntities.ProductDto
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double  Rating { get; set; }

        public string File { get; set; }
    }
}