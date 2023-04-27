using Data.Models;
using Data.ViewModel;

namespace ChatApi.Services.ChatService
{
    public interface IChat
    {
        List<DateTimeViewModel> GetSpecificChatData(int fromuserid, int touserid);
        Task<tbChat> InsertChatData(string message, int fromuserid, int touserid);
        Task<tbChat> InsertChat(tbChat chat);
    }
}
