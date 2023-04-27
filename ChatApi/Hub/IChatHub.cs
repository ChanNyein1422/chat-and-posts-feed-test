namespace ChatApi.Hub
{
    public interface IChatHub
    {
        Task SendMessage(string message, int fromUserId, int toUserId);

    }
}
