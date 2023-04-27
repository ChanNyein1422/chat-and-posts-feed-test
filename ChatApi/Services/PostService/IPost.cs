using Data.Models;
using Data.ViewModel;

namespace ChatApi.Services.PostService
{
    public interface IPost
    {
        Task<List<UserPostViewModel>> GetAllPosts();

        tbPost GetPostById(int id);

        Task<tbPost> UpSert(tbPost post);

        int DeletePost(int id);
    }
}
