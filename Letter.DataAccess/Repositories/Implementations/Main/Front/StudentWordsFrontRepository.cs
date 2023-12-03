using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class StudentWordsFrontRepository : GenericRepository<StudentWordsFront>, IStudentWordsFrontRepository
    {
        public StudentWordsFrontRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<StudentWordsFront>> GetAllStudentWordsFront()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<StudentWordsFront> GetLastStudentWordsFront()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }

        public async Task<StudentWordsFront> GetStudentWordsFtont(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
