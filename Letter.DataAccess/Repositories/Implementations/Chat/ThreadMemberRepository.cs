using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Chat;
using Letter.DataAccess.Repositories.Abstractions.Chat;

namespace Letter.DataAccess.Repositories.Implementions.Chat
{
    public class ThreadMemberRepository : GenericRepository<ThreadMember>, IThreadMemberRepository
    {
        public ThreadMemberRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }
    }
}
