using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Chat;
using Letter.DataAccess.Repositories.Abstractions.Chat;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementions.Chat
{
    public class MessageThreadRepository : GenericRepository<MessageThread>, IMessageThreadRepository
    {
        public MessageThreadRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

        IEnumerable<MessageThread> IMessageThreadRepository.GetUserThreads(int userId)
        {
            return GetAsQueryable()
                .Include(x => x.ThreadMembers)
                .Where(x => x.ThreadMembers.Select(x => x.UserId).Contains(userId));
        }
    }
}
