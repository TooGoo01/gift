using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class HomePageRepository : GenericRepository<HomePage>, IHomePageRepository
    {
        public HomePageRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<HomePage> GetHomePageById(int id)
        {
            return await GetAsQueryable()
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HomePage> GetLastHomePage()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }
        public async Task<IEnumerable<HomePage>> GetAllHomePages()
        {
            return await GetAsQueryable().ToListAsync();
        }
    }
}
