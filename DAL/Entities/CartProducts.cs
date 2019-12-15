namespace DAL.Entities
{
    public class CartProducts
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}