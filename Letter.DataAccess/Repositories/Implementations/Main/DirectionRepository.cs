//using Letter.DataAccess.Context;
//using Letter.DataAccess.Entities.Main;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using Microsoft.EntityFrameworkCore;

//namespace Letter.DataAccess.Repositories.Implementations.Main
//{
//    public class DirectionRepository : GenericRepository<Direction>, IDirectionRepository
//    {
//        public DirectionRepository(LetterDbContext educationDbContext) : base(educationDbContext)
//        {

//        }

//        public async Task<Direction> GetDirection(int id)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Specialities.Where(x1=>x1.IsActive==true))
//                .Include(x => x.DirectionFiles)
//                .Include(x => x.Universities.Where(z => z.IsActive == true))
//                .ThenInclude(y => y.Country)
//                .Include(x => x.Universities.Where(z => z.IsActive == true))
//                .ThenInclude(y => y.UniversityFiles)
//                .FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<ICollection<Direction>> GetAllDirections()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Specialities)
//                .Include(x => x.DirectionFiles)
//                .ToListAsync();
//        }

//        public async Task<ICollection<Direction>> GetActiveDirections()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Specialities.Where(x1=>x1.IsActive==true))
//                .Include(x => x.DirectionFiles)
//                .Where(x => x.IsActive)
//                .OrderBy(x => x.Id)
//                .ToListAsync();
//        }

//        public async Task<ICollection<Direction>> GetActiveDirectionsOrderAzName()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Specialities.Where(x1 => x1.IsActive == true))
//                .Include(x => x.DirectionFiles)
//                .Where(x => x.IsActive)
//                .OrderBy(x => x.AzName)
//                .ToListAsync();
//        }

//        public async Task<ICollection<Direction>> GetActiveDirectionsOrderEnName()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Specialities.Where(x1 => x1.IsActive == true))
//                .Include(x => x.DirectionFiles)
//                .Where(x => x.IsActive)
//                .OrderBy(x => x.EnName)
//                .ToListAsync();
//        }

//        public async Task<ICollection<Direction>> GetActiveDirectionsOrderRuName()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Specialities.Where(x1 => x1.IsActive == true))
//                .Include(x => x.DirectionFiles)
//                .Where(x => x.IsActive)
//                .OrderBy(x => x.RuName)
//                .ToListAsync();
//        }
//    }
//}
