using BLL.DtoEntities.CommentDto;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Task2_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateCommentDto commentDto)
        {
            return Ok(_commentService.CreateComment(commentDto));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateComment(UpdateCommentDto commentDto)
        {
            return Ok(_commentService.UpdateCommentDto(commentDto));
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult RemoveComment(int id)
        {
            _commentService.RemoveComment(id);
            return Ok();
        }
    }
}