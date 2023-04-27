using ChatApi.Services.UserService;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser _iUser;
        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpGet("api/user/getallusers")]
        public List<tbUser> GetAllUsers()
        {
            return this._iUser.GetAllUsers().ToList();
        }

        [HttpGet("api/user/getallusersexcept")]
        public List<tbUser> GetAllUsersExcept(int id)
        {
            return this._iUser.GetAllUsers().Where(u => u.id != id).ToList();
        }

        [HttpGet("api/user/getuserbyusername")]
        public tbUser GetUserByUsername(string username)
        {
            return this._iUser.GetAllUsers().Where(a => a.username == username).FirstOrDefault();
        }

        [HttpPost("api/user/upsert")]
        public async Task<IActionResult> UpSert(tbUser user)
        {
            user = await this._iUser.UpSert(user);
            return Ok(user);
        }



        [HttpGet("api/user/getuserbyid")]
        public IActionResult GetUserById(int id)
        {
            var user = this._iUser.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("api/user/deleteuser")]
        public IActionResult DeleteUser(int id)
        {
            var user = this._iUser.UserDelete(id);
            return Ok(user);
        }

    }
}
