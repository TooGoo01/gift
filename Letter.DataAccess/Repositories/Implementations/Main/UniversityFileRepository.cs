using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class UniversityFileRepository : GenericRepository<HomeFile>, IUniversityFileRepository
    {
        public UniversityFileRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }
    }
}
