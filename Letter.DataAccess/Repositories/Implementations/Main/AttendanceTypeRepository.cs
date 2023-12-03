using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;


namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class AttendanceTypeRepository : GenericRepository<AttendanceType>, IAttendanceTypeRepository
    {
        public AttendanceTypeRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<AttendanceType>> GetActiveAttendanceTypes()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<AttendanceType>> GetAllAttendanceTypes()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<AttendanceType> GetAttendanceType(int id)
        {
            return await GetAsQueryable()
               .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
