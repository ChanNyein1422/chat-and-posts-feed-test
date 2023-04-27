using Data.Models;

namespace Data.ViewModel
{
    public class UserCommentViewModel
    {
        public tbComment? comment { get; set; }
        public tbUser? user { get; set; }

    }

    public class CommentMainModel
    {
        public int PostId { get; set; }
        public List<UserCommentViewModel> model { get; set; }
    }
}
