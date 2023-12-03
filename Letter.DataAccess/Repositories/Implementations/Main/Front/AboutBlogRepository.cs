using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class AboutBlogRepository : GenericRepository<AboutBlog>, IAboutBlogRepository
    {
        public AboutBlogRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<AboutBlog> GetAboutBlogById(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.Blogs.AsQueryable())
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutBlog> GetLastAboutBlog()
        {
            return await GetAsQueryable()
               .Include(x => x.Blogs)
               .OrderBy(x => x.Id)
               .LastOrDefaultAsync();
        }

        public async Task<IEnumerable<AboutBlog>> GetAllAboutBlogs()
        {
            return await GetAsQueryable()
                .Include(x => x.Blogs.AsQueryable())
                .ToListAsync();
        }
    }
}
