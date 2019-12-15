using BLL.DtoEntities.CommentDto;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        CommentInfoDto CreateComment(CreateCommentDto commentDto);

        UpdateCommentDto UpdateCommentDto(UpdateCommentDto commentDto);

        void RemoveComment(int id);
    }
}