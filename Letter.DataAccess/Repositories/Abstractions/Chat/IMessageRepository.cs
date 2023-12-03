using Letter.DataAccess.Entities.Chat;

namespace Letter.DataAccess.Repositories.Abstractions.Chat
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Message GetLastMessage(int threadId);
    }
}
