using Core.Extensions;
using Data.Models;
using Data.ViewModel;
using Infra.UnitOfWork;

namespace ChatApi.Services.ChatService
{
    public class ChatBase : IChat
    {
        private DatabaseContext _dbContext;
        UnitOfWork _unitOfWork;

        public ChatBase(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            this._unitOfWork = new UnitOfWork(_dbContext);
        }

        public List<DateTimeViewModel> GetSpecificChatData(int fromuserid, int touserid)
        {
            const int groupHours = 1;
            TimeSpan interval = new TimeSpan(groupHours, 0, 0);
            var result = _unitOfWork.ChatRepo.GetAll().Where(c => c.fromUserId == fromuserid &&
                c.toUserId == touserid || c.fromUserId == touserid
                && c.toUserId == fromuserid).OrderByDescending(x => x.accesstime).ToList();

            var data = (from dt in result
                        group dt by dt.accesstime.Ticks / interval.Ticks into g
                        select new DateTimeViewModel
                        { Key = new DateTime(g.Key * interval.Ticks), chat = g.ToList() }).ToList();
            return data;

        }

        public async Task<tbChat> InsertChatData(string message, int fromuserid, int touserid)
        {
            tbChat chat = new tbChat();
            chat.message = message;
            chat.fromUserId = fromuserid;
            chat.toUserId = touserid;
            chat.accesstime = MyExtensions.getLocalTime();
            chat = await _unitOfWork.ChatRepo.InsertReturnAsync(chat);
            return chat;
        }

        public async Task<tbChat> InsertChat(tbChat chat)
        {
            chat.accesstime = MyExtensions.getLocalTime();
            chat = await _unitOfWork.ChatRepo.InsertReturnAsync(chat);
            return chat;
        }
    }
}
