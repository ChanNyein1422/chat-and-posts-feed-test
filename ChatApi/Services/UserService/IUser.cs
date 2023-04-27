using Data.Models;


namespace ChatApi.Services.UserService
{
    public interface IUser
    {
        List<tbUser> GetAllUsers();
        tbUser GetUserById(int id);
        Task<tbUser> UpSert(tbUser user);
        int UserDelete(int id);

    }
}
