using Data.Models;

namespace Infra.Helper
{
    public static class UserRequestHelper
    {
        public static async Task<tbUser> GetUserByUsername(string username)
        {
            var url = string.Format("api/user/getuserbyusername?username={0}", username);
            var result = await ApiRequest<tbUser>.GetRequest(url.route(Request.chatappapi));
            return result;
        }

        public static async Task<List<tbUser>> GetAllUserExcept(int id)

        {
            var url = string.Format("api/user/getallusersexcept?id={0}", id);
            var result = await ApiRequest<List<tbUser>>.GetRequest(url.route(Request.chatappapi));
            return result;
        }
    }
}
