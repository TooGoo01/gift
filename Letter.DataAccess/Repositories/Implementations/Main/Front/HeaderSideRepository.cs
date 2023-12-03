//using Letter.DataAccess.Context;
//using Letter.DataAccess.Entities.Main.Front;
//using Letter.DataAccess.Repositories.Abstractions.Main.Front;
//using Microsoft.EntityFrameworkCore;

//namespace Letter.DataAccess.Repositories.Implementations.Main.Front
//{
//    public class HeaderSideRepository : GenericRepository<HeaderSide>, IHeaderSideRepository
//    {
//        public HeaderSideRepository(LetterDbContext educationDbContext) : base(educationDbContext)
//        {
//        }

//        public async Task<HeaderSide> GetHeaderSideById(int id)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Countries)
//                .Include(x => x.Programs)
//                .FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<HeaderSide> GetLastHeaderSide()
//        {
//            return await GetAsQueryable()
//                .OrderBy(x => x.Id)
//                .Include(x => x.Countries)
//                .Include(x => x.Programs)
//                .LastOrDefaultAsync();
//        }
//        public async Task<IEnumerable<HeaderSide>> GetAllHeaderSides()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Countries)
//                .Include(x => x.Programs)
//                .ToListAsync();
//        }
//    }
//}
