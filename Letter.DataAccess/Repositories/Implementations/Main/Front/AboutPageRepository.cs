using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class AboutPageRepository : GenericRepository<AboutPage>, IAboutPageRepository
    {
        public AboutPageRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<AboutPage> GetAboutPagePageById(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.AboutPageFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutPage> GetLastAboutPagePage()
        {
            return await GetAsQueryable()
                .Include(x => x.AboutPageFiles)
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }
        public async Task<IEnumerable<AboutPage>> GetAllAboutPages()
        {
            return await GetAsQueryable()
                .Include(x => x.AboutPageFiles)
                .ToListAsync();
        }
    }
}
