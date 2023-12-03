using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class StudentRequestRepository : GenericRepository<StudentRequest>, IStudentRequestRepository
    {
        public StudentRequestRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<ICollection<StudentRequest>> GetActiveStudentRequests()
        {
            return await GetAsQueryable()
              //.Include(x => x.YourContry)
              .Include(x => x.Countries.AsQueryable())
              .Include(x => x.Directions.AsQueryable())
              .Where(x => x.IsActive == true)
              .ToListAsync();
        }
        public async Task<StudentRequest> GetLastStudentRequest()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
              .LastOrDefaultAsync();
        }

        public async Task<ICollection<StudentRequest>> GetAllStudentRequests()
        {
            return await GetAsQueryable()
               //.Include(x => x.YourContry)
               .Include(x => x.Countries.AsQueryable())
               .Include(x => x.Directions.AsQueryable())
               .ToListAsync();
        }


        public async Task<StudentRequest> GetStudentRequest(int id)
        {
            return await GetAsQueryable()
               //.Include(x => x.YourContry)
               .Include(x => x.Countries)
               .Include(x => x.Directions)
               .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<ICollection<StudentRequest>> GetStudentRequestsByCountry(string country)
        {
            return await GetAsQueryable()
               //.Include(x => x.YourContry)
               .Include(x => x.Countries.AsQueryable())
               .Include(x => x.Directions.AsQueryable())
               .Where(x => x.YourCountry == country)
               .ToListAsync();
        }

        public async Task<ICollection<StudentRequest>> GetSeenStudentRequests()
        {
            return await GetAsQueryable()
                .Where(x => x.Seen == true)
                .ToListAsync();
        }
        
        public async Task<ICollection<StudentRequest>> GetNonSeenStudentRequests()
        {
            return await GetAsQueryable()
                .Where(x => x.Seen == false)
                .ToListAsync();
        }
    }
}
