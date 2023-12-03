using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class BlogFrontRepository : GenericRepository<BlogFront>, IBlogFrontRepository
    {
        public BlogFrontRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<BlogFront>> GetAllBlogFront()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<BlogFront> GetBlogFront(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogFront> GetLastBlogFront()
        {
            return await GetAsQueryable()
                 .OrderBy(x => x.Id)
                 .LastOrDefaultAsync();
        }
    }
}
