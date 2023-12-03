using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        public ContentRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<Content> GetContentById(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.ContentFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Content> GetLastContent()
        {
            return await GetAsQueryable()
                .Include(x => x.ContentFiles)
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }

        public async Task<IEnumerable<Content>> GetAllContents()
        {
            return await GetAsQueryable()
                .Include(x => x.ContentFiles)
                .ToListAsync();
        }
    }
}
