using Core.Extensions;
using Data.Models;
using Infra.Helper;
using Infra.UnitOfWork;

namespace ChatApi.Services.UserService
{
    public class UserBase : IUser
    {
        private DatabaseContext _dbContext;
        UnitOfWork _unitOfWork;

        public UserBase(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            this._unitOfWork = new UnitOfWork(_dbContext);
        }

        public List<tbUser> GetAllUsers()
        {
            return _unitOfWork.UserRepo.GetAll().ToList();
        }

        public async Task<tbUser> UpSert(tbUser user)
        {
            try
            {

                if (user.id > 0)
                {
                    user = await _unitOfWork.UserRepo.UpdateAsync(user);
                }
                else
                {
                    user.accesstime = MyExtensions.getLocalTime();
                    user.password = PasswordHelper.EncryptPassword(user.password);
                    user = await _unitOfWork.UserRepo.InsertReturnAsync(user);
                    //
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

        public tbUser GetUserById(int id)
        {
            return _unitOfWork.UserRepo.GetById(id);
        }

        public int UserDelete(int id)
        {
            var user = _unitOfWork.UserRepo.GetAll().FirstOrDefault(data => data.id == id);
            if (user != null)
            {
                _unitOfWork.UserRepo.Delete(user);
                return 1;
            }
            return 0;
        }


    }
}
