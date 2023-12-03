using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

        public async Task<List<About>> GetAbouts()
        {
            return await GetAsQueryable()
                .Include(x => x.AboutFiles)
                .ToListAsync();
        }

        public async Task<About> GetAbout(int aboutId)
        {
            return await GetAsQueryable()
                .Include(x => x.AboutFiles)
                .FirstOrDefaultAsync(x => x.Id == aboutId);
        }

        public async Task<List<About>> GetActiveAbouts()
        {
            return await GetAsQueryable()
                .Include(x => x.AboutFiles)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }
    }
}
