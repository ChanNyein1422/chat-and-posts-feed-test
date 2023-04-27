using Core.Extensions;
using Data.Models;
using Data.ViewModel;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Services.CommentService
{
    public class CommentBase : IComment
    {
        private DatabaseContext _dbcontext;
        UnitOfWork _unitOfWork;

        public CommentBase(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
            this._unitOfWork = new UnitOfWork(_dbcontext);
        }
        public int DeleteComment(int id)
        {
            var comment = _unitOfWork.CommentRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (comment != null)
            {
                _unitOfWork.CommentRepo.Delete(comment);
                return 1;
            }
            return 0;
        }

        public tbComment GetCommentById(int id)
        {
            return _unitOfWork.CommentRepo.GetById(id);
        }

        public async Task<CommentMainModel> GetCommentByPost(int PostId)
        {
            IQueryable<UserCommentViewModel> query = from c in _unitOfWork.CommentRepo.GetAll().Where(a => a.IsDeleted != true && a.PostId == PostId)
                                                     join u in _unitOfWork.UserRepo.GetAll()
                                                     on c.CommenterId equals u.id

                                                     select new UserCommentViewModel
                                                     {
                                                         comment = c,
                                                         user = u,

                                                     };
            var data = await query.OrderBy(a => a.comment.Id).ToListAsync();
            CommentMainModel model = new CommentMainModel()
            {
                model = data,
                PostId = PostId
            };
            return model;
        }

        public async Task<tbComment> UpSert(tbComment comment)
        {
            try
            {
                var post = _unitOfWork.PostRepo.GetById(comment.PostId);
                if (post != null)
                {
                    if (comment.Id > 0)
                    {
                        comment = await _unitOfWork.CommentRepo.UpdateAsync(comment);
                    }
                    else
                    {
                        comment.AccessTime = MyExtensions.getLocalTime();
                        comment = await _unitOfWork.CommentRepo.InsertReturnAsync(comment);
                    }
                }
                else
                {
                    comment = new tbComment();
                    comment.ReturnMessage = "No Post";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comment;
        }
    }
}

