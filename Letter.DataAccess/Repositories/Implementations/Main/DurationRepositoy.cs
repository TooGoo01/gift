//using Letter.DataAccess.Context;
//using Letter.DataAccess.Entities.Main;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using Microsoft.EntityFrameworkCore;

//namespace Letter.DataAccess.Repositories.Implementations.Main
//{
//    public class DurationRepositoy : GenericRepository<Duration>, IDurationRepositoy
//    {
//        public DurationRepositoy(LetterDbContext educationDbContext) : base(educationDbContext)
//        {
//        }

//        public async Task<Duration> GetDuration(int id)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.DurationDate)
//                 .Include(x => x.University)
//                .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<IEnumerable<Duration>> GetDurations()
//        {
//            return await GetAsQueryable()
//                 .Include(x => x.DurationDate)
//                 .Include(x => x.University)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .ToListAsync();
//        }


//        public async Task<IEnumerable<Duration>> GetDurationsBySpeciality(int specialityId)
//        {
//            return await GetAsQueryable().Include(x => x.DurationDate)
//                .Include(x => x.University)
//                 //  .ThenInclude(x => x.UniversityFiles)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.SpecialityId == specialityId)
//                 .ToListAsync();
//        }
//        public async Task<IEnumerable<Duration>> GetDurationsByProgram(int programId)
//        {
//            return await GetAsQueryable().Include(x => x.DurationDate)
//                .Include(x => x.University)
//                 //  .ThenInclude(x => x.UniversityFiles)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.LetterProgramId == programId)
//                 .ToListAsync();
//        }
//        public async Task<IEnumerable<Duration>> GetDurationsByUniveristy(int univeristyId)
//        {
//            return await GetAsQueryable().Include(x => x.DurationDate)
//                .Include(x => x.University)
//                 // .ThenInclude(x => x.UniversityFiles)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.UniversityId == univeristyId)
//                 .ToListAsync();
//        }
//        public async Task<IEnumerable<Duration>> GetDurationsByUniveristyProgram(int univeristyId, int programId)
//        {
//            return await GetAsQueryable().Include(x => x.DurationDate)
//                .Include(x => x.University)
//                 // .ThenInclude(x => x.UniversityFiles)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.UniversityId == univeristyId && x.LetterProgramId == programId)
//                 .ToListAsync();
//        }

//        public async Task<IEnumerable<Duration>> GetDurationsByUniveristySpeciality(int univeristyId, int specialityId)
//        {
//            return await GetAsQueryable().Include(x => x.DurationDate)
//                .Include(x => x.University)
//                 //  .ThenInclude(x => x.UniversityFiles)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.UniversityId == univeristyId && x.SpecialityId == specialityId)
//                 .ToListAsync();
//        }

//        public async Task<IEnumerable<Duration>> GetActiveDurations()
//        {
//            return await GetAsQueryable()
//               .Include(x => x.DurationDate)
//               .Include(x => x.University)
//               .Include(x => x.Speciality)
//               .Include(x => x.LetterProgram)
//               .Where(x => x.IsActive == true)
//               .ToListAsync();
//        }
//    }
//}
