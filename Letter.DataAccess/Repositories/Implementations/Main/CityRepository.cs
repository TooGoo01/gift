using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Context;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }

        public async Task<IEnumerable<City>> GetActiveCities()
        {
            return await GetAsQueryable()
                .Include(x => x.CityFiles)
                .Include(x => x.Places)
                .Include(x => x.Icons)
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        //public async Task<IEnumerable<City>> GetRandomActiveCountries()
        //{
        //    var list = await GetAsQueryable()
        //        .Include(x => x.CountryFiles)
        //        .Where(x => x.IsActive == true)
        //        .ToListAsync();

        //    int[] idArray = list.Select(x => x.Id).ToArray();

        //    Random rnd = new Random();

        //    var countryList = new List<City>();
        //    List<int> existIds = new List<int>();

        //    while (countryList.Count < list.Count)
        //    {
        //        var rndId = rnd.Next(idArray.Length);
        //        if (!existIds.Contains(rndId))
        //        {
        //            existIds.Add(rndId);
        //            countryList.Add(list.FirstOrDefault(x => x.Id == idArray[rndId]));
        //        }
        //    }
        //    return countryList;
        //}
        public async Task<IEnumerable<City>> GetDeActiveCities()
        {
            return await GetAsQueryable()
                .Include(x => x.CityFiles)
                 .Include(x => x.Places)
                .Include(x => x.Icons)
                .Where(x => x.IsActive == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<City>> GetAllCountries()
        {
            return await GetAsQueryable()
                .Include(x => x.CityFiles)
                 .Include(x => x.Places)
                .Include(x => x.Icons)
                .ToListAsync();
        }

        public async Task<City> GetCity(int cityId)
        {
            return await GetAsQueryable()
                .Include(x => x.CityFiles)
                 .Include(x => x.Places)
                .Include(x => x.Icons)
                .FirstOrDefaultAsync(x => x.Id == cityId);
        }

        public async Task<IEnumerable<City>> GetCountriesIdName()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public Task<IEnumerable<City>> GetAllCities()
        {
            throw new NotImplementedException();
        }

        

      
    }
}
