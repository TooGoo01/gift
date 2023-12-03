using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    internal class GoStudyFrontRepository : GenericRepository<GoStudyFront>, IGoStudyFrontRepository
    {
        public GoStudyFrontRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<GoStudyFront>> GetAllGoStudyFronts()
        {
            return await GetAsQueryable()
               .Include(x => x.GoStudyFiles)
               .ToListAsync();
        }

        public async Task<GoStudyFront> GetGoStudyFronts(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.GoStudyFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public  async Task<GoStudyFront> GetLastGoStudyFronts()
        {
            return await GetAsQueryable()
                 .Include(x => x.GoStudyFiles)
                 .OrderBy(x => x.Id)
                 .LastOrDefaultAsync();
        }
    }
}
