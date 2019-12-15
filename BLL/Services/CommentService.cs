using BLL.DtoEntities.CommentDto;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _db;

        public CommentService(IUnitOfWork db)
        {
            _db = db;
        }


        public CommentInfoDto CreateComment(CreateCommentDto commentDto)
        {
            var comment = commentDto.ToComment();
            _db.Comments.Add(comment);
            _db.Save();

            comment = _db.Comments.GetWithUser(comment.Id);
            
            return comment.ToCommentInfo();
        }

        public UpdateCommentDto UpdateCommentDto(UpdateCommentDto commentDto)
        {
            var comment = _db.Comments.GetById(commentDto.Id);

            comment.Text = commentDto.Text;
            comment.Rating = commentDto.Rating;
            
            _db.Comments.Update(comment);
            _db.Save();

            return commentDto;
        }

        public void RemoveComment(int id)
        {
            var comment = _db.Comments.GetById(id);
            _db.Comments.Remove(comment);
        }
    }
}