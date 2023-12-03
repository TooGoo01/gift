using Letter.DataAccess.Entities.Chat;

namespace Letter.DataAccess.Repositories.Abstractions.Chat
{
    public interface IMessageThreadRepository : IGenericRepository<MessageThread>
    {
        IEnumerable<MessageThread> GetUserThreads(int userId);
    }
}
