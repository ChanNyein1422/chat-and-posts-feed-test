using ChatApi.Services.CommentService;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    public class CommentController : Controller
    {
        IComment _iComment;
        public CommentController(IComment iComment)
        {
            _iComment = iComment;
        }

        [HttpGet("api/comment/getcommentbypost")]
        public async Task<IActionResult> GetCommentByPostAsync(int postId)
        {
            var data = await this._iComment.GetCommentByPost(postId);
            return Ok(data);
        }
        [HttpGet("api/comment/getcommentbyid")]
        public tbComment GetCommentById(int id)
        {
            var data = this._iComment.GetCommentById(id);
            return data;
        }
        [HttpPost("api/comment/upsert")]
        public async Task<IActionResult> UpSert(tbComment comment)
        {

            comment = await this._iComment.UpSert(comment);
            return Ok(comment);
        }
        [HttpGet("api/comment/delete")]
        public IActionResult DeleteComment(int id)
        {
            var comment = this._iComment.DeleteComment(id);
            return Ok(comment);
        }
    }
}
