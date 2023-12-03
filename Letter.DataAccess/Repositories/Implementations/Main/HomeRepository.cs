using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Context;
using Letter.DataAccess.Extensions;
using Letter.DataAccess.Models;
using Letter.DataAccess.Repositories.Abstractions.Main;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Letter.DataAccess.Entities.Main;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class HomeRepository : GenericRepository<Home>, IHomeRepository
    {
        public HomeRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

        //public IQueryable<Home> SearcProduct(UniversitySearchModel searchModel)
        //{
        //    var query = GetAsQueryable()
        //        .Include(x => x.Country)
        //        .Include(x => x.Directions)
        //        .Include(x => x.Programs)
        //        .Include(x => x.Specialities)
        //        .Include(x => x.UniversityFiles)
        //        .Include(x => x.Durations)
        //        .ThenInclude(x => x.DurationDate)
        //        .Include(x => x.Attendances)
        //        .ThenInclude(x => x.AttendanceType)
        //        .Where(x => x.IsActive);

        //    if (searchModel.CountryNames != null && searchModel.CountryNames.Any())
        //    {
        //        var countryPredicate = PredicateBuilder.False<Home>();
        //        foreach (var countryName in searchModel.CountryNames)
        //        {
        //            countryPredicate = countryPredicate.Or(x => x.Country.AzName == countryName
        //                || x.Country.EnName == countryName
        //                || x.Country.RuName == countryName);
        //        }
        //        query = query.Where(countryPredicate);
        //    }

        //    if (searchModel.DirectionNames != null && searchModel.DirectionNames.Any())
        //    {
        //        var directionPredicate = PredicateBuilder.False<Home>();
        //        foreach (var directionName in searchModel.DirectionNames)
        //        {
        //            directionPredicate = directionPredicate.Or(x => x.Directions.Any(d => d.AzName == directionName
        //                || d.EnName == directionName
        //                || d.RuName == directionName));
        //        }
        //        query = query.Where(directionPredicate);
        //    }

        //    if (searchModel.SpecialityNames != null && searchModel.SpecialityNames.Any())
        //    {
        //        var specialityPredicate = PredicateBuilder.False<Home>();
        //        foreach (var specialityName in searchModel.SpecialityNames)
        //        {
        //            specialityPredicate = specialityPredicate.Or(x => x.Specialities.Any(s => s.AzName == specialityName
        //                || s.EnName == specialityName
        //                || s.RuName == specialityName));
        //        }
        //        query = query.Where(specialityPredicate);
        //    }

        //    if (searchModel.ProgramNames != null && searchModel.ProgramNames.Any())
        //    {
        //        var programPredicate = PredicateBuilder.False<Home>();
        //        foreach (var programName in searchModel.ProgramNames)
        //        {
        //            programPredicate = programPredicate.Or(x => x.Programs.Any(p => p.AzName == programName
        //                || p.EnName == programName
        //                || p.RuName == programName));
        //        }
        //        query = query.Where(programPredicate);
        //    }

        //    if (searchModel.Addresses != null && searchModel.Addresses.Any())
        //    {
        //        var addressPredicate = PredicateBuilder.False<Home>();
        //        foreach (var address in searchModel.Addresses)
        //        {
        //            addressPredicate = addressPredicate.Or(x => x.EnAddress == address);
        //        }
        //        query = query.Where(addressPredicate);
        //    }

        //    if (searchModel.Durations != null && searchModel.Durations.Any())
        //    {
        //        var durationPredicate = PredicateBuilder.False<Home>();
        //        foreach (var duration in searchModel.Durations)
        //        {
        //            durationPredicate = durationPredicate.Or(x => x.Durations.Any(d => d.DurationDate.Date == duration));
        //        }
        //        query = query.Where(durationPredicate);
        //    }

        //    if (searchModel.Attendances != null && searchModel.Attendances.Any())
        //    {
        //        var attendancePredicate = PredicateBuilder.False<Home>();
        //        foreach (var attendance in searchModel.Attendances)
        //        {
        //            attendancePredicate = attendancePredicate.Or(x => x.Attendances.Any(a => a.AttendanceType.Title == attendance));
        //        }
        //        query = query.Where(attendancePredicate);
        //    }

        //    return query.OrderBy(x => x.Id);
        //}

        #region NonWorkingSearchs
        //public IQueryable<University> SearcProduct(UniversitySearchModel searchModel)
        //{
        //    var query = GetAsQueryable()
        //        .Include(x => x.Country)
        //        .Include(x => x.Directions)
        //        .Include(x => x.Programs)
        //        .Include(x => x.Specialities)
        //        .Include(x => x.Durations)
        //        .ThenInclude(x => x.DurationDate)
        //        .Include(x => x.Attendances)
        //        .ThenInclude(x => x.AttendanceType)
        //        .Where(x => x.IsActive);

        //    if (searchModel.CountryNames?.Count > 0)
        //    {
        //        query = query.Where(x => searchModel.CountryNames.Contains(x.AzName)
        //                                 || searchModel.CountryNames.Contains(x.EnName)
        //                                 || searchModel.CountryNames.Contains(x.RuName));
        //    }

        //    if (searchModel.SpecialityNames?.Count > 0)
        //    {
        //        query = query.Where(x => x.Specialities.Any(y => searchModel.SpecialityNames.Contains(y.AzName)
        //                                                         || searchModel.SpecialityNames.Contains(y.EnName)
        //                                                         || searchModel.SpecialityNames.Contains(y.RuName)));
        //    }

        //    if (searchModel.ProgramNames?.Count > 0)
        //    {
        //        query = query.Where(x => x.Programs.Any(y => searchModel.ProgramNames.Contains(y.AzName)
        //                                                     || searchModel.ProgramNames.Contains(y.EnName)
        //                                                     || searchModel.ProgramNames.Contains(y.RuName)));
        //    }

        //    if (searchModel.DirectionNames?.Count > 0)
        //    {
        //        query = query.Where(x => x.Directions.Any(y => searchModel.DirectionNames.Contains(y.AzName)
        //                                                       || searchModel.DirectionNames.Contains(y.EnName)
        //                                                       || searchModel.DirectionNames.Contains(y.RuName)));
        //    }

        //    if (searchModel.Addresses?.Count > 0)
        //    {
        //        query = query.Where(x => searchModel.Addresses.Contains(x.Address));
        //    }

        //    if (searchModel.Durations?.Count > 0)
        //    {
        //        query = query.Where(x => x.Durations.Any(y => searchModel.Durations.Contains(y.DurationDate.Date)));
        //    }

        //    if (searchModel.Attendances?.Count > 0)
        //    {
        //        query = query.Where(x => x.Attendances.Any(y => searchModel.Attendances.Contains(y.AttendanceType.Title)));
        //    }

        //    return query.OrderBy(x => x.Id);
        //}

        //public IQueryable<University> SearcProduct(UniversitySearchModel searchModel)
        //{
        //    var predicate = GeneratePredicate(searchModel);

        //    var data = GetAsQueryable()
        //                 .Include(x => x.Country)
        //                 .Include(x => x.Directions)
        //                 .Include(x => x.Programs)
        //                 .Include(x => x.Specialities)
        //                 .Include(x => x.Durations)
        //                 .ThenInclude(x => x.DurationDate)
        //                 .Include(x => x.Attendances)
        //                 .ThenInclude(x => x.AttendanceType)
        //                 .Where(predicate)
        //                 .OrderBy(x => x.Id);
        //    return data;
        //}


        /*   private Expression<Func<University, bool>> GeneratePredicate(UniversitySearchModel searchModel)
           {
               var predicate = PredicateBuilder.True<University>();

               // Filter by country names
               if (searchModel.CountryNames.Count > 0)
               {
                   var countryPredicate = from u in predicate
                                          where searchModel.CountryNames.Contains(u.AzName)
                                          || searchModel.CountryNames.Contains(u.EnName)
                                          || searchModel.CountryNames.Contains(u.RuName)
                                          select u;

                   predicate = predicate.And(countryPredicate);
               }

               // Filter by speciality names
               if (searchModel.SpecialityNames.Count > 0)
               {
                   var specialityPredicate = from u in predicate
                                             where u.Specialities.Any(s => searchModel.SpecialityNames.Contains(s.AzName)
                                             || searchModel.SpecialityNames.Contains(s.EnName)
                                             || searchModel.SpecialityNames.Contains(s.RuName))
                                             select u;

                   predicate = predicate.And(specialityPredicate);
               }

               // Filter by program names
               if (searchModel.ProgramNames.Count > 0)
               {
                   var programPredicate = from u in predicate
                                          where u.Programs.Any(p => searchModel.ProgramNames.Contains(p.AzName)
                                          || searchModel.ProgramNames.Contains(p.EnName)
                                          || searchModel.ProgramNames.Contains(p.RuName))
                                          select u;

                   predicate = predicate.And(programPredicate);
               }

               // Filter by direction names
               if (searchModel.DirectionNames.Count > 0)
               {
                   var directionPredicate = from u in predicate
                                            where u.Directions.Any(d => searchModel.DirectionNames.Contains(d.AzName)
                                            || searchModel.DirectionNames.Contains(d.EnName)
                                            || searchModel.DirectionNames.Contains(d.RuName))
                                            select u;

                   predicate = predicate.And(directionPredicate);
               }

               // Filter by addresses
               if (searchModel.Addresses.Count > 0)
               {
                   var addressPredicate = from u in predicate
                                          where searchModel.Addresses.Contains(u.Address)
                                          select u;

                   predicate = predicate.And(addressPredicate);
               }

               // Filter by durations
               if (searchModel.Durations.Count > 0)
               {
                   var durationPredicate = from u in predicate
                                           where u.Durations.Any(d => searchModel.Durations.Contains(d.DurationDate.Date))
                                           select u;

                   predicate = predicate.And(durationPredicate);
               }

               // Filter by attendances
               if (searchModel.Attendances.Count > 0)
               {
                   var attendancePredicate = from u in predicate
                                             where u.Attendances.Any(a => searchModel.Attendances.Contains(a.AttendanceType.Title))
                                             select u;

                   predicate = predicate.And(attendancePredicate);
               }

               // Add filter for active universities
               predicate = predicate.And(u => u.IsActive);

               return predicate;
           }*/

        //private Expression<Func<University, bool>> GeneratePredicate(UniversitySearchModel searchModel)
        //{
        //    var predicate = PredicateBuilder.True<University>();
        //    if ((searchModel.CountryNames.Count != 0) || (searchModel.SpecialityNames.Count != 0) || (searchModel.ProgramNames.Count != 0) || (searchModel.DirectionNames.Count != 0)
        //        || (searchModel.Addresses.Count != 0) || (searchModel.Durations.Count != 0) || (searchModel.Attendances.Count != 0))
        //    {
        //        if (searchModel.CountryNames.Count != 0)
        //        {
        //            foreach (var item in searchModel.CountryNames)
        //            {
        //                predicate = predicate.Or(x => x.AzName == item || x.EnName == item || x.RuName == item);
        //            }
        //        }

        //        if (searchModel.SpecialityNames.Count != 0)
        //        {
        //            foreach (var item in searchModel.SpecialityNames)
        //            {
        //                predicate = predicate.Or(x => x.Specialities.Any(y => y.AzName == item || y.EnName == item || y.RuName == item));
        //            }
        //        }

        //        if (searchModel.ProgramNames.Count != 0)
        //        {
        //            foreach (var item in searchModel.ProgramNames)
        //            {
        //                predicate = predicate.Or(x => x.Programs.Any(y => y.AzName == item || y.EnName == item || y.RuName == item));
        //            }
        //        }

        //        if (searchModel.DirectionNames.Count != 0)
        //        {
        //            foreach (var item in searchModel.DirectionNames)
        //            {
        //                predicate = predicate.Or(x => x.Directions.Any(y => y.AzName == item || y.EnName == item || y.RuName == item));
        //            }
        //        }

        //        if (searchModel.Addresses.Count != 0)
        //        {
        //            foreach (var item in searchModel.Addresses)
        //            {
        //                predicate = predicate.Or(x => x.Address == item);
        //            }
        //        }

        //        if (searchModel.Durations.Count != 0)
        //        {
        //            foreach (var item in searchModel.Durations)
        //            {
        //                predicate = predicate.Or(x => x.Durations.Any(y => y.DurationDate.Date == item));
        //            }
        //        }

        //        if (searchModel.Attendances.Count != 0)
        //        {
        //            foreach (var item in searchModel.Attendances)
        //            {
        //                predicate = predicate.Or(x => x.Attendances.Any(y => y.AttendanceType.Title == item));
        //            }
        //        }
        //    }

        //    return predicate.And(x => x.IsActive);
        //}

        #endregion

        //public async Task<List<University>> GetAllUniverities()
        //{
        //    return await GetAsQueryable()
        //        .AsNoTracking()
        //        .Include(x => x.UniversityFiles)
        //        .Include(x => x.Programs)
        //        .Include(x => x.Directions)
        //        .ToListAsync();
        //}



        public async Task<List<Home>> GetAllHomes()
        {
            return await GetAsQueryable()
                .AsNoTracking()
                .Include(x => x.City)
                
                .Include(x=>x.Type)
                .Include(x=>x.HomeFiles)
                .ToListAsync();
        }




        public async Task<List<Home>> GetActiveHomes()
        {
            //return await GetAsQueryable()
            //    .Include(x => x.UniversityFiles)
            //    .Include(x => x.Country)
            //    .Include(x => x.Programs)
            //    .Include(x => x.Directions)
            //    .Where(x => x.IsActive == true)
            //    //&& x.Directions.Any(y => y.IsActive == true)
            //    //&& x.Programs.Any(y2 => y2.IsActive == true)
            //    //&& x.Specialities.Any(y3 => y3.IsActive == true)
            //    //&& x.Attendances.Any(y4 => y4.IsActive == true)
            //    //&& x.Durations.Any(y5 => y5.IsActive == true))
            //    .ToListAsync();

            return await GetAsQueryable()
               .AsNoTracking()
               .Include(x => x.City)
                .Include(x => x.Type)
                .Include(x => x.HomeFiles)
                .Include(x => x.TimeType)
               .Where(x => x.IsActive == true)
               .ToListAsync();
        }
        public async Task<List<Home>> GetActiveHomesName()
        {
            //return await GetAsQueryable()
            //    .Where(x => x.IsActive == true)
            //    .ToListAsync();
            return await GetAsQueryable()
               .AsNoTracking()
               .Select(u => new Home
               {
                   Id = u.Id,
                   AzName = u.AzName,
                   EnName = u.EnName,
                   RuName = u.RuName,
                   IsActive = u.IsActive,
                   
               })
               .Where(x => x.StatusId == 4)
               .Where(x => x.IsActive == true)
               .ToListAsync();
        }

        public async Task<Home> GetHome(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.HomeFiles)
                .Include(x => x.City)
                .Include(x => x.Type)
                .Include(x => x.Status)
                .Include(x => x.TimeType)
                .FirstOrDefaultAsync(x => x.Id == id);

            //return await GetAsQueryable()
            //   .AsNoTracking()
            //   .Include(x => x.Country)
            //   .ThenInclude(y => y.CountryFiles)
            //   .Select(u => new University
            //   {
            //       Id = u.Id,
            //       AzName = u.AzName,
            //       EnName = u.EnName,
            //       RuName = u.RuName,
            //       AzDescription = u.AzDescription,
            //       EnDescription = u.EnDescription,
            //       RuDescription = u.RuDescription,
            //       MapAdrress = u.MapAdrress,
            //       Address = u.Address,
            //       StudentCount = u.StudentCount,
            //       AcademicStaff = u.AcademicStaff,
            //       AzAbout = u.AzAbout,
            //       EnAbout = u.EnAbout,
            //       RuAbout = u.AzAbout,
            //       AzStudentLife = u.AzStudentLife,
            //       EnStudentLife = u.EnStudentLife,
            //       RuStudentLife = u.RuStudentLife,
            //       AzServices = u.AzServices,
            //       EnServices = u.EnServices,
            //       RuServices = u.RuServices,
            //       AzBachelor = u.AzBachelor,
            //       EnBachelor = u.EnBachelor,
            //       RuBachelor = u.RuBachelor,
            //       AzMaster = u.AzMaster,
            //       EnMaster = u.EnMaster,
            //       RuMaster = u.RuMaster,
            //       Rank = u.Rank,
            //       StartDate = u.StartDate,
            //       ApplyDate = u.ApplyDate,
            //       Programs = u.Programs.Select(p => new LetterProgram
            //       {
            //           Id = p.Id,
            //           AzName = p.AzName,
            //           EnName = p.EnName,
            //           RuName = p.RuName,
            //       }).ToList(),
            //       Directions = u.Directions.Select(d => new Direction
            //       {
            //           Id = d.Id,
            //           AzName = d.AzName,
            //           EnName = d.EnName,
            //           RuName = d.RuName,
            //       }).ToList(),
            //       Specialities = u.Specialities.Select(s => new Speciality
            //       {
            //           Id = s.Id,
            //           AzName = s.AzName,
            //           EnName = s.EnName,
            //           RuName = s.RuName,
            //           Direction= s.Direction,
            //       }).ToList(),
            //       UniversityFiles = u.UniversityFiles,
            //       IsActive = u.IsActive
            //   })
            //   .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Home>> GetHomesByCity(int cityId)
        {
            return await GetAsQueryable()
                .Include(x => x.HomeFiles)
                .Include(x => x.City)
                .Include(x => x.Type)
                
                .Where(x => x.City.Id == cityId && x.IsActive == true)
                // && x.Directions.Any(y => y.IsActive == true)
                //&& x.Programs.Any(y2 => y2.IsActive == true)
                //&& x.Specialities.Any(y3 => y3.IsActive == true)
                //&& x.Attendances.Any(y4 => y4.IsActive == true)
                //&& x.Durations.Any(y5 => y5.IsActive == true))
                .ToListAsync();
        }

        public IQueryable<Home> SearcHome(HomeSearchModel searchModel)
        {
            var query = GetAsQueryable()
                .Include(x => x.City)
                .Include(x => x.Type)
                .Include(x => x.TimeType)
                .Include(x => x.HomeFiles)
                .Where(x=>x.StatusId==4)
                .Where(x => x.IsActive);
            if (searchModel.HomeName != null && searchModel.HomeName.Any())
            {
                var homePredicate = PredicateBuilder.False<Home>();
                
                    homePredicate = homePredicate.Or(x => x.AzName.Contains(searchModel.HomeName)
                        || x.EnName.Contains(searchModel.HomeName)
                        || x.RuName.Contains(searchModel.HomeName));
                
                query = query.Where(homePredicate);
            }
            if (searchModel.TypeIds != null && searchModel.TypeIds.Any())
            {
                var typePredicate = PredicateBuilder.False<Home>();
                foreach (var typeId in searchModel.TypeIds)
                {
                    typePredicate = typePredicate.Or(x => x.TypeId == typeId);
                }
                query = query.Where(typePredicate);
            }   
            if (searchModel.CityIds != null && searchModel.CityIds.Any())
            {
                var cityPredicate = PredicateBuilder.False<Home>();
                foreach (var cityId in searchModel.CityIds)
                {
                    cityPredicate = cityPredicate.Or(x => x.CityId == cityId);
                }
                query = query.Where(cityPredicate);
            }  
            if (searchModel.TimeTypeIds != null && searchModel.TimeTypeIds.Any())
            {
                var timePredicate = PredicateBuilder.False<Home>();
                foreach (var timeTypeId in searchModel.TimeTypeIds)
                {
                    timePredicate = timePredicate.Or(x => x.TimeTypeId == timeTypeId);
                }
                query = query.Where(timePredicate);
            }  
              
            return query.OrderBy(x => x.Id);
        }

        public Task<IEnumerable<Home>> GetRandomActiveHomes()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Home>> GetHomeByUserId(int userId)
        {
            return await GetAsQueryable()
                 .Include(x => x.HomeFiles)
                 .Include(x => x.City)
                 .Include(x => x.Type)
                 .Where(x=>x.RegUserId==userId )
                 .ToListAsync();
        }

        public async Task<List<Home>> GetHomesByTypeId(string typeName)
        {
            return await GetAsQueryable()
                  .Include(x => x.HomeFiles)
                  .Include(x => x.City)
                  .Include(x => x.Type)
                  .Where(x => x.Type.EnName == typeName)
                  .ToListAsync();
        }

        public async Task<List<Home>> GetHomesByTypeName(string typeName)
        {
            return await GetAsQueryable()
                  .Include(x => x.HomeFiles)
                  .Include(x => x.City)
                  .Include(x => x.Type)
                  .Include(x => x.TimeType)
                  .Where(x => x.Type.EnName == typeName)
                  .ToListAsync();
        }

        public async Task<List<Home>> GetHomesByStatusId(int statusId)
        {
            return await GetAsQueryable()
                 .Include(x => x.City)
                .Include(x => x.Type)
                .Include(x => x.HomeFiles)
                .Include(x => x.TimeType)
               .Where(x => x.IsActive == true)
                 .Where(x => x.StatusId==statusId)
                 .ToListAsync();
        }

        //public async Task<IEnumerable<Home>> GetRandomActiveUniversities()
        //{
        //    var list = await GetAsQueryable()
        //        .Include(x => x.UniversityFiles)
        //        .Where(x => x.IsActive == true )
        //        .ToListAsync();

        //    int[] idArray = list.Select(x => x.Id).ToArray();

        //    Random rnd = new Random();

        //    var universityList = new List<Home>();
        //    List<int> existIds = new List<int>();

        //    while (universityList.Count < list.Count)
        //    {
        //        var rndId = rnd.Next(idArray.Length);
        //        if (!existIds.Contains(rndId))
        //        {
        //            existIds.Add(rndId);
        //            universityList.Add(list.FirstOrDefault(x => x.Id == idArray[rndId]));
        //        }
        //    }
        //    return universityList;
        //}
    }
}
