//using Letter.DataAccess.Context;
//using Letter.DataAccess.Entities.Main;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using Microsoft.EntityFrameworkCore;

//namespace Letter.DataAccess.Repositories.Implementations.Main
//{
//    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
//    {
//        public AttendanceRepository(LetterDbContext educationDbContext) : base(educationDbContext)
//        {
//        }

//        public async Task<Attendance> GetAttendance(int id)
//        {
//            return await GetAsQueryable()
//                 .Include(x => x.AttendanceType)
//                 .Include(x => x.University)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<IEnumerable<Attendance>> GetAttendances()
//        {
//            return await GetAsQueryable()
//                 .Include(x => x.AttendanceType)
//                 .Include(x => x.University)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .ToListAsync();
//        }

//        public async Task<IEnumerable<Attendance>> GetAttendancesBySpeciality(int specialityId)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.AttendanceType)
//                .Include(x => x.AttendanceType)
//                .Include(x => x.University)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.SpecialityId == specialityId)
//                 .ToListAsync();
//        }
//        public async Task<IEnumerable<Attendance>> GetAttendancesByProgram(int programId)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.AttendanceType)
//                .Include(x => x.University)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.LetterProgramId == programId)
//                 .ToListAsync();
//        }
//        public async Task<IEnumerable<Attendance>> GetAttendancesByUniveristy(int univeristyId)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.AttendanceType)
//                .Include(x => x.University)
//                .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.UniversityId == univeristyId)
//                 .ToListAsync();
//        }
//        public async Task<IEnumerable<Attendance>> GetAttendancesByUniveristyProgram(int univeristyId, int programId)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.AttendanceType)
//               .Include(x => x.University)
//                .Include(x => x.Speciality)
//                .Include(x => x.LetterProgram)
//                 .Where(x => x.UniversityId == univeristyId && x.LetterProgramId == programId)
//                 .ToListAsync();
//        }

//        public async Task<IEnumerable<Attendance>> GetAttendancesByUniveristySpeciality(int univeristyId, int specialityId)
//        {
//            return await GetAsQueryable()
//                .Include(x => x.AttendanceType)
//               .Include(x => x.University)
//                .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.UniversityId == univeristyId && x.SpecialityId == specialityId)
//                 .ToListAsync();
//        }

//        public async Task<IEnumerable<Attendance>> GetActiveAttendances()
//        {
//            return await GetAsQueryable()
//                 .Include(x => x.AttendanceType)
//                 .Include(x => x.University)
//                 .Include(x => x.Speciality)
//                 .Include(x => x.LetterProgram)
//                 .Where(x => x.IsActive == true)
//                 .ToListAsync();
//        }
//    }
//}
