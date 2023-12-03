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

    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<List<Status>> GetActiveStatus()
        {
            return await GetAsQueryable()
             .Where(x => x.IsActive)
             .ToListAsync();
        }

        public async Task<List<Status>> GetAllStatus()
        {
            return await GetAsQueryable()
               .ToListAsync();
        }

        public async Task<Status> GetFirstStatus()
        {
            return await GetAsQueryable().Where(x=>x.IsActive).FirstAsync();
               
        }

        public async Task<Status> GetStatus(int id)
        {
            return await GetAsQueryable()
                  .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
