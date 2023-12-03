using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class DirectionFrontRepository : GenericRepository<DirectionFront>, IDirectionFrontRepository
    {
        public DirectionFrontRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<DirectionFront> GetLastDirectionFront()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }

        public async Task<IEnumerable<DirectionFront>> GetAllDirectionFront()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<DirectionFront> GetDirectionFront(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
