using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class BodySideRepository : GenericRepository<BodySide>, IBodySideRepository
    {
        public BodySideRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<BodySide> GetBodySideById(int id)
        {
            return await GetAsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BodySide> GetLastBodySide()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }

        public async Task<IEnumerable<BodySide>> GetAllBodySides()
        {
            return await GetAsQueryable().ToListAsync();
        }
    }
}
