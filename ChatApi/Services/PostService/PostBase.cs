using Core.Extensions;
using Data.Models;
using Data.ViewModel;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Services.PostService
{
    public class PostBase : IPost
    {
        private DatabaseContext _databaseContext;
        UnitOfWork _unitOfWork;

        public PostBase(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            this._unitOfWork = new UnitOfWork(_databaseContext);
        }

        public async Task<List<UserPostViewModel>> GetAllPosts()
        {
            IQueryable<UserPostViewModel> result = from p in _unitOfWork.PostRepo.GetAll().Where(a => a.isDeleted != true)
                                                   join u in _unitOfWork.UserRepo.GetAll()
                                                   on p.userId equals u.id

                                                   select new UserPostViewModel
                                                   {
                                                       post = p,
                                                       user = u
                                                   };
            var data = await result.OrderByDescending(a => a.post.Id).ToListAsync();
            return data;
            
        }

        public tbPost GetPostById(int id)
        {
            return _unitOfWork.PostRepo.GetById(id);
        }

        public int DeletePost(int id)
        {
            var post = _unitOfWork.PostRepo.GetAll().FirstOrDefault(x => x.Id == id);
            var comments = _unitOfWork.CommentRepo.GetAll().Where(c => c.PostId == id);
            if (post != null)
            {
                _unitOfWork.PostRepo.Delete(post);
                if (comments != null)
                {
                    foreach (var comment in comments)
                    {
                        _unitOfWork.CommentRepo.Delete(comment);
                    }
                }
                return 1;
            }
            return 0;
        }

        public async Task<tbPost> UpSert(tbPost post)
        {
            try
            {
                if (post.Id > 0)
                {
                    post = await _unitOfWork.PostRepo.UpdateAsync(post);

                }
                else
                {
                    post.accessTime = MyExtensions.getLocalTime();
                    post = await _unitOfWork.PostRepo.InsertReturnAsync(post);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return post;
        }
    }
}
