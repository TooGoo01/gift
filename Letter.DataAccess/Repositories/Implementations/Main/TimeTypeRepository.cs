using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;


namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class TimeTypeRepository : GenericRepository<TimeType>, ITimeTypeRepository
    {
        public TimeTypeRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

 

        public async Task<List<TimeType>> GetAllTimeTypes()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<List<TimeType>> GetActiveTimeTypes()
        {
            return await GetAsQueryable()
               .Where(x => x.IsActive)
               .ToListAsync();
        }

        public async Task<TimeType> GetTimeType(int id)
        {
            return await GetAsQueryable()
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
