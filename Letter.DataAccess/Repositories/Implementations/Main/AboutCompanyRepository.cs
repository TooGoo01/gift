using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class AboutCompanyRepository : GenericRepository<AboutCompany>, IAboutCompanyRepository
    {
        public AboutCompanyRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<List<AboutCompany>> GetActiveAboutCompanies()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<AboutCompany> GetAboutCompany(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AboutCompany>> GetAllAboutCompanies()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
        public async Task<AboutCompany> GetLastAboutCompany()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .Where(x => x.IsActive == true)
                .LastOrDefaultAsync();
        }
    }
}
