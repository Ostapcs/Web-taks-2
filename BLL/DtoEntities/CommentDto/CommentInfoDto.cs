using BLL.DtoEntities.UserDto;

namespace BLL.DtoEntities.CommentDto
{
    public class CommentInfoDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        public PreviewUserDto User { get; set; }
    }
}