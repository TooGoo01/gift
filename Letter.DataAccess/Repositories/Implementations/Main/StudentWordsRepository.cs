
using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class StudentWordsRepository : GenericRepository<StudentWords>, IStudentWordsRepository
    {
        public StudentWordsRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<List<StudentWords>> GetActiveStudentWords()
        {
            return await GetAsQueryable()
                 .Include(x => x.StudentFiles)
                 .Include(x => x.Country)
                 .Where(x => x.IsActive == true)
                 .ToListAsync();
        }

        public async Task<List<StudentWords>> GetAllStudentWords()
        {
            return await GetAsQueryable()
                .Include(x => x.StudentFiles)
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<StudentWords> GetStudentWords(int id)
        {
            return await GetAsQueryable()
                 .Include(x => x.StudentFiles)
                 .Include(x => x.Country)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<StudentWords>> GetStudentWordsByCountry(int countryId)
        {
            return await GetAsQueryable()
                .Include(x => x.StudentFiles)
                .Include(x => x.Country)
                .Where(x => x.CountryId == countryId)
                .ToListAsync();
        }
    }
}
