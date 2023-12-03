//using Letter.Business.Dtos.Get.Main;
//using Letter.DataAccess.Context;
//using Letter.DataAccess.Models;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using LinqKit;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;

//namespace Letter.DataAccess.Repositories.Implementations.Main
//{
//    public class SpecialityRepository : GenericRepository<Speciality>, ISpecialityRepository
//    {
//        public SpecialityRepository(LetterDbContext educationDbContext) : base(educationDbContext)
//        {

//        }

//        public async Task<Speciality> GetSpeciality(int id)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Directions)
//                .Include(x => x.Attendances)
//                .Include(x => x.Durations)
//                .Include(x => x.Universities.Where(z=>z.IsActive==true))
//                .ThenInclude(y => y.UniversityFiles)
//                .Include(x => x.Universities)
//                .ThenInclude(y => y.Country)
//                .FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<List<Speciality>> GetAllSpecialities()
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Directions)
//                .Include(x => x.Attendances)
//                .Include(x => x.Durations)
//                .ToListAsync();
//        }
//        public async Task<List<Speciality>> GetSpecialitiesViaDirection(int id)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.Directions.Where(x => x.Id == id))
//                .Include(x => x.Attendances)
//                .Include(x => x.Durations)
//                .ToListAsync();
//        }

//        public async Task<List<Speciality>> GetActiveSpecialities()
//        {
//            return await GetAsQueryable()
//               .Include(x => x.Directions)
//               .Include(x => x.Attendances)
//               .Include(x => x.Durations)
//               .Where(x => x.IsActive)
//               .ToListAsync();
//        }

//        public IQueryable<Speciality> SearcProduct(SpecialitySearchModel searchModel)
//        {
//            var data = GetAsQueryable()
//                         .Where(GeneratePredicate(searchModel))
//                         .OrderBy(x => x.Id);
//            return data;
//        }

//        private Expression<Func<Speciality, bool>> GeneratePredicate(SpecialitySearchModel searchModel)
//        {
//            var predicate = PredicateBuilder.True<Speciality>();
//            if (searchModel.DirectionIds != null && searchModel.DirectionIds.Any())
//            {
//                predicate = PredicateBuilder.False<Speciality>();
//                foreach (var directId in searchModel.DirectionIds)
//                {
//                    predicate = predicate.Or(x => x.Directions.Any(s => s.Id == directId));
//                }
//            }
//            return predicate.And(x => x.IsActive);
//        }

//    }
//}
