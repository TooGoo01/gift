using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class HomeTypeRepository : GenericRepository<HomeType>, IHomeTypeRepository
    {
        public HomeTypeRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

        public async Task<List<HomeType>> GetActiveTypes()
        {
            return await GetAsQueryable()
               .Where(x => x.IsActive)
               .ToListAsync();
        }

        public async Task<HomeType> GetType(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<HomeType>> GetAllTypes()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
    }
}
