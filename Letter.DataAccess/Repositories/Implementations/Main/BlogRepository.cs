using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

        public async Task<ICollection<Blog>> GetBlogs()
        {
            return await GetAsQueryable().Include(x => x.BlogFiles).ToListAsync();
        }

        public async Task<Blog> GetBlog(int blogId)
        {
            return await GetAsQueryable().Include(x => x.BlogFiles).FirstOrDefaultAsync(x => x.Id == blogId);
        }

        public async Task<ICollection<Blog>> GetActiveBlogs()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
                .Include(x => x.BlogFiles).ToListAsync();
        }

        public async Task<ICollection<Blog>> GetActiveBlogsWithoutFile()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }
    }
}
