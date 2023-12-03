using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class DirectionFileRepository : GenericRepository<DirectionFile>, IDirectionFileRepository
    {
        public DirectionFileRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }
    }
}
