using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class ContactPageRepository : GenericRepository<ContactPage>, IContactPageRepository
    {
        public ContactPageRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<ContactPage> GetContactPageById(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.ContactPageFiles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContactPage> GetLastContactPage()
        {
            return await GetAsQueryable()
                .Include(x => x.ContactPageFiles)
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync();
        }

        public async Task<IEnumerable<ContactPage>> GetAllContactPages()
        {
            return await GetAsQueryable()
                .Include(x => x.ContactPageFiles)
                .ToListAsync();
        }
    }
}
