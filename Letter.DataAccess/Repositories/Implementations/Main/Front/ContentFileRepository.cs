using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class ContentFileRepository : GenericRepository<ContentFile>, IContentFileRepository
    {
        public ContentFileRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }
    }
}
