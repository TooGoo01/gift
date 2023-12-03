using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class PartnerFileRepository : GenericRepository<PartnerFile>, IPartnerFileRepository
    {
        public PartnerFileRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }
    }
}
