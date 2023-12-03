using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class AboutCountryRepository : GenericRepository<AboutCountry>, IAboutCountryRepository
    {
        public AboutCountryRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<AboutCountry> GetAboutCountrybyId(int id)
        {
            return await GetAsQueryable()
                 .Include(x => x.Countries.AsQueryable())
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutCountry> GetLastAboutCountry()
        {
            return await GetAsQueryable().OrderBy(x => x.Id)
                .Include(x => x.Countries.AsQueryable())
                .LastOrDefaultAsync();
        }
        public async Task<IEnumerable<AboutCountry>> GetAllAboutCountries()
        {
            return await GetAsQueryable()
                .Include(x => x.Countries)
                .ToListAsync();
        }
    }
}
