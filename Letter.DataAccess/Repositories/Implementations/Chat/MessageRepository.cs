using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Chat;
using Letter.DataAccess.Repositories.Abstractions.Chat;

namespace Letter.DataAccess.Repositories.Implementions.Chat
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

        public Message GetLastMessage(int threadId)
        {
            return GetAsQueryable()
                .OrderByDescending(x => x.RegDate)
                .FirstOrDefault(x => x.ThreadId == threadId);
        }
    }
}
