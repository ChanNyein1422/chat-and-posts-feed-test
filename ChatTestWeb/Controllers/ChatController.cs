using Data.Models;
using Infra.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ChatTestWeb.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatView()
        {
            return View();
        }

        public IActionResult _chatlist()
        {
            return PartialView("_chatlist");
        }

        public async Task<IActionResult> _userlist(int id)
        {
            var users = await UserRequestHelper.GetAllUserExcept(id);
            return PartialView("_userlist", users);

        }

        public async Task<IActionResult> IdentifyUser(string username)
        {
            var user = await UserRequestHelper.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public async Task<IActionResult> GetSpecificChatData(int fromuserid, int touserid)
        {
            var chatdata = await ChatRequestHelper.GetSpecificChatData(fromuserid, touserid);
            return Ok(chatdata);
        }

        public async Task<IActionResult> InsertChatData(string message, int fromuserid, int touserid)
        {
            var chatdata = await ChatRequestHelper.InsertChatData(message, fromuserid, touserid);
            return Ok(chatdata);
        }

        public async Task<IActionResult> InsertChat(tbChat chat)
        {
            chat.accesstime = DateTime.UtcNow;
            var data = await ChatRequestHelper.InsertChat(chat);
            return Ok(data);
        }
    }
}
