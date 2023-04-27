using Data.Models;
using Data.ViewModel;

namespace Infra.Helper
{
    public static class ChatRequestHelper
    {
        public static async Task<List<DateTimeViewModel>> GetSpecificChatData(int fromuserid, int touserid)
        {
            var url = string.Format("api/chat/getspecificchatdata?fromuserid={0}&touserid={1}", fromuserid, touserid);
            var result = await ApiRequest<List<DateTimeViewModel>>.GetRequest(url.route(Request.chatappapi));
            return result;

        }

        public static async Task<tbChat> InsertChatData(string message, int fromuserid, int touserid)
        {
            var url = string.Format("api/chat/insertchatdata?message={0}&fromuserid={1}&touserid={2}", message, fromuserid, touserid);
            var result = await ApiRequest<tbChat>.GetRequest(url.route(Request.chatappapi));
            return result;
        }

        public static async Task<tbChat> InsertChat(tbChat chat)
        {
            var url = string.Format("api/chat/insertchat");
            var result = await ApiRequest<tbChat>.PostRequest(url.route(Request.chatappapi), chat);
            return result;
        }
    }
}
