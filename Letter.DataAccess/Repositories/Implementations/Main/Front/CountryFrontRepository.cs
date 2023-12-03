using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class CountryFrontRepository : GenericRepository<CountryFront>, ICountryFrontRepository
    {
        public CountryFrontRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<CountryFront>> GetAllCountryFronts()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<CountryFront> GetCountryFronts(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CountryFront> GetLastCountryFronts()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }
    }
}
