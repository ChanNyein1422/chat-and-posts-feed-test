using ChatApi.Services.PostService;
using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    public class PostController : Controller
    {
        IPost _iPost;
        public PostController(IPost iPost)
        {
            _iPost = iPost;
        }
        [HttpGet("api/post/getallposts")]
        public Task<List<UserPostViewModel>> GetAllPosts()
        {
            return this._iPost.GetAllPosts();
        }
        [HttpGet("api/post/getpostbyid")]
        public IActionResult GetPostByID(int id)
        {
            var post = this._iPost.GetPostById(id);
            return Ok(post);
        }
        [HttpGet("api/post/deletepost")]
        public IActionResult DeletePost(int id)
        {
            var post = this._iPost.DeletePost(id);
            return Ok(post);
        }
        [HttpPost("api/post/upsert")]
        public async Task<IActionResult> UpSert(tbPost post)
        {
            post = await this._iPost.UpSert(post);
            return Ok(post);
        }

    }
}
