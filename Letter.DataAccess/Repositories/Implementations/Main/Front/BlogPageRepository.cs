using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class BlogPageRepository : GenericRepository<BlogPage>, IBlogPageRepository
    {
        public BlogPageRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<BlogPage> GetBlogPageById(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.BlogPageFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPage> GetLastBlogPage()
        {
            return await GetAsQueryable()
                .Include(x => x.BlogPageFiles)
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }
        public async Task<IEnumerable<BlogPage>> GetAllBlogPages()
        {
            return await GetAsQueryable()
                .Include(x => x.BlogPageFiles)
                .ToListAsync();
        }
    }
}
