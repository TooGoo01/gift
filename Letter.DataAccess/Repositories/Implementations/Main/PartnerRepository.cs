using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class PartnerRepository : GenericRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<Partner>> GetActivePartners()
        {
            return await GetAsQueryable()
              .Include(x => x.PartnerFiles)
              .Where(x => x.IsActive == true)
             .ToListAsync();
        }

        public async Task<Partner> GetPartner(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.PartnerFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Partner>> GetAllPartners()
        {
            return await GetAsQueryable()
                .Include(x => x.PartnerFiles)
               .ToListAsync();
        }
    }
}
