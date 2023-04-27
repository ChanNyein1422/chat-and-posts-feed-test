using Data.Models;
using Data.ViewModel;

namespace ChatApi.Services.CommentService
{
    public interface IComment
    {


        Task<CommentMainModel> GetCommentByPost(int PostId);
        tbComment GetCommentById(int id);
        Task<tbComment> UpSert(tbComment comment);
        int DeleteComment(int id);
    }
}
