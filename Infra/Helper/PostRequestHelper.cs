using Data.Models;
using Data.ViewModel;

namespace Infra.Helper
{
    public static class PostRequestHelper
    {
        public static async Task<List<UserPostViewModel>> GetAllPosts()
        {
            var url = string.Format("api/post/getallposts");
            var result = await ApiRequest<List<UserPostViewModel>>.GetRequest(url.route(Request.chatappapi));
            return result;
        }
        public static async Task<tbPost> UpSert(tbPost post)
        {
            var url = string.Format("api/post/upsert");
            var result = await ApiRequest<tbPost>.PostRequest(url.route(Request.chatappapi), post);
            return result;
        }
    }
}
