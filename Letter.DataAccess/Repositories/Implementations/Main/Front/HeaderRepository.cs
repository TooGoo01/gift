using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class HeaderRepository : GenericRepository<Header>, IHeaderRepository
    {
        public HeaderRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<Header>> GetActiveHeaders()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        public async Task<Header> GetHeader(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Header>> GetHeaders()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
    }
}
