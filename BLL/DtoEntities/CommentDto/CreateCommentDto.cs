namespace BLL.DtoEntities.CommentDto
{
    public class CreateCommentDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}