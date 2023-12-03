using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class PartnerFrontRepository : GenericRepository<PartnerFront>, IPartnerFrontRepository
    {
        public PartnerFrontRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<PartnerFront>> GetAllPartnersFront()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<PartnerFront> GetLastPartnerFront()
        {
            return await GetAsQueryable()
                 .OrderBy(x => x.Id)
                 .LastOrDefaultAsync();
        }

        public async Task<PartnerFront> GetPartnerFront(int id)
        {
            return await GetAsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
