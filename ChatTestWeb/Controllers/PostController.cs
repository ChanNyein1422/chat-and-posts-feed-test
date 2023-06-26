using Data.Models;
using Infra.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ChatTestWeb.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult PostView()
        {
            return View();
        }
        public IActionResult _postlist()
        {
            return PartialView("_postlist");
        }
        public IActionResult _addpost(int userId)
        {
            tbPost post = new tbPost();
            post.userId = userId;
            return PartialView("_addpost", post);

        }
        public IActionResult _addpostbase64(int userId)
        {
            tbPost post = new tbPost();
            post.userId = userId;
            return PartialView("_addpostbase64", post);

        }
        public async Task<IActionResult> GetAllPosts()
        {

            var postdata = await PostRequestHelper.GetAllPosts();
            
            if (postdata == null)
            {
                return NotFound();
            }

            return PartialView("_postlist", postdata);
        }
        [HttpPost]
        public async Task<IActionResult> InsertPost(tbPost post, IFormFile files)
        {
            post.accessTime = DateTime.Now;
            if (files != null)
            {
                string fileName = Path.GetFileName(files.FileName);
                post.postPhoto = fileName;
                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ImageUpload", fileName);
                var stream = new FileStream(uploadpath, FileMode.Create);
                files.CopyToAsync(stream);
            }
            var postdata = await PostRequestHelper.UpSert(post);
            return Ok(postdata);
        }

        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }
        public async Task<IActionResult> InsertPostBase64(tbPost post)
        {
            post.accessTime = DateTime.Now;
            if (post.postPhoto != null)
            {
                var ext = GetFileExtension(post.postPhoto);

                string imageName = Guid.NewGuid() + "." + ext;

                //set the image path
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ImageUpload", imageName);

                byte[] imageBytes = Convert.FromBase64String(post.postPhoto);

                System.IO.File.WriteAllBytes(imgPath, imageBytes);

                post.postPhoto = imageName;
            }

            var postdata = await PostRequestHelper.UpSert(post);

            return Ok(postdata);
        }
        public async Task<IActionResult> GetCommentByPost(int postId)
        {
            var commentdata = await CommentRequestHelper.GetCommentByPost(postId);
            if (commentdata == null)
            {
                return NotFound();
            }
            return PartialView("_commentview", commentdata);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(tbComment comment)
        {
            comment.AccessTime = DateTime.Now;
            var commentdata = await CommentRequestHelper.AddComment(comment);
            return Ok(commentdata);
        }

    }
}
