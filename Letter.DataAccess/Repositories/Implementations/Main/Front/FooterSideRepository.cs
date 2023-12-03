//using Letter.DataAccess.Context;
//using Letter.DataAccess.Entities.Main.Front;
//using Letter.DataAccess.Repositories.Abstractions.Main.Front;
//using Microsoft.EntityFrameworkCore;

//namespace Letter.DataAccess.Repositories.Implementations.Main.Front
//{
//    public class FooterSideRepository : GenericRepository<FooterSide>, IFooterSideRepository
//    {
//        public FooterSideRepository(LetterDbContext educationDbContext) : base(educationDbContext)
//        {
//        }

//        public async Task<FooterSide> GetFooterSideById(int id)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Countries)
//                .Include(x => x.Programs)
//                .FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<FooterSide> GetLastFooterSide()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Countries)
//                .Include(x => x.Programs)
//                .OrderBy(x => x.Id)
//                .LastOrDefaultAsync();
//        }
//        public async Task<IEnumerable<FooterSide>> GetAllFooterSides()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Countries)
//                .Include(x => x.Programs)
//                .ToListAsync();
//        }
//    }
//}
