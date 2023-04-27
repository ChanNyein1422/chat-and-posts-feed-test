using Data.Models;
using Data.ViewModel;

namespace Infra.Helper
{
    public class CommentRequestHelper
    {
        public static async Task<CommentMainModel> GetCommentByPost(int postId)
        {
            var url = string.Format("api/comment/getcommentbypost?postid={0}", postId);
            var result = await ApiRequest<CommentMainModel>.GetRequest(url.route(Request.chatappapi));
            return result;
        }

        public static async Task<tbComment> AddComment(tbComment comment)
        {
            var url = string.Format("api/comment/upsert");
            var result = await ApiRequest<tbComment>.PostRequest(url.route(Request.chatappapi), comment);
            return result;
        }
    }
}
