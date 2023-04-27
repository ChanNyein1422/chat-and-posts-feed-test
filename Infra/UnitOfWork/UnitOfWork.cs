using Data.Models;
using Infra.Repository;

namespace Infra.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private IRepository<tbUser>? _tbUserRepository;
        private IRepository<tbChat>? _tbChatRepository;
        private IRepository<tbPost>? _tbPostRepository;
        private IRepository<tbComment>? _tbCommentRepository;

        private DatabaseContext _ctx;
        private bool _isDisposed;

        public UnitOfWork(DatabaseContext ctx)
        {
            _ctx = ctx;
        }



        ~UnitOfWork()
        {
            _ctx.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!_isDisposed)
            {
                if (disposing)
                {
                    _ctx?.Dispose();
                }
                _ctx = null;
                _isDisposed = true;
            }
        }

        public IRepository<tbUser> UserRepo
        {
            get
            {
                if (_tbUserRepository == null)
                {
                    _tbUserRepository = new Repository<tbUser>(_ctx);
                }
                return _tbUserRepository;
            }
        }

        public IRepository<tbChat> ChatRepo
        {
            get
            {
                if (_tbChatRepository == null)
                {
                    _tbChatRepository = new Repository<tbChat>(_ctx);
                }
                return _tbChatRepository;
            }
        }
        public IRepository<tbPost> PostRepo
        {
            get
            {
                if (_tbPostRepository == null)
                {
                    _tbPostRepository = new Repository<tbPost>(_ctx);
                }
                return _tbPostRepository;
            }
        }
        public IRepository<tbComment> CommentRepo
        {
            get
            {
                if (_tbCommentRepository == null)
                {
                    _tbCommentRepository = new Repository<tbComment>(_ctx);
                }
                return _tbCommentRepository;
            }
        }




    }
}
