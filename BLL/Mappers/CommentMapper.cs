using BLL.DtoEntities.CommentDto;
using DAL.Entities;

namespace BLL.Mappers
{
    public static class CommentMapper
    {
        public static CommentInfoDto ToCommentInfo(this Comment comment)
        {
            return new CommentInfoDto
            {
                Id = comment.Id,
                Rating = comment.Rating,
                Text = comment.Text,
                User = comment.User.ToPreviewUser()
            };
        }

        public static Comment ToComment(this CreateCommentDto commentDto)
        {
            return new Comment
            {
                Text = commentDto.Text,
                UserId = commentDto.UserId,
                ProductId = commentDto.ProductId
            };
        }
    }
}