using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class DurationDateRepository : GenericRepository<DurationDate>, IDurationDateRepository
    {
        public DurationDateRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<DurationDate>> GetActiveDurationDates()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
               .ToListAsync();
        }

        public async Task<IEnumerable<DurationDate>> GetAllDurationDates()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<DurationDate> GetDurationDate(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
