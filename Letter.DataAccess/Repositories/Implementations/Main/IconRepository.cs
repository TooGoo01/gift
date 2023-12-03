using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class IConRepository : GenericRepository<Icon>, IIconRepository
    {
        public IConRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<Icon>> GetActiveIcons()
        {
            return await GetAsQueryable()
                 .Where(x => x.IsActive == true)
                 .ToListAsync();
        }

        public async Task<Icon> GetIcon(int iconId)
        {
            return await GetAsQueryable()
          
               .FirstOrDefaultAsync(x => x.Id == iconId);
        }

        public async Task<IEnumerable<Icon>> GetIcons()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }
    }
}
