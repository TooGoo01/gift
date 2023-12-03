using Letter.Business.Dtos.Get.Main;
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
    public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<IEnumerable<Place>> GetActivePlaces()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
                .Include(x => x.PlaceFiles)
                .Include(x => x.City).ThenInclude(x=>x.CityFiles)
                .ToListAsync();
        }

        public async Task<Place> GetPlace(int placeId)
        {
            return await GetAsQueryable()
            .Include(x => x.PlaceFiles)
            .Include(x => x.City).ThenInclude(x => x.CityFiles)
                .FirstOrDefaultAsync(x => x.Id == placeId);
        }

        public async Task<IEnumerable<Place>> GetPlaceByCityId(int cityId)
        {
            return  await GetAsQueryable()
               .Include(x => x.PlaceFiles)
               .Include(x => x.City).ThenInclude(x => x.CityFiles)
               .Where(x => x.cityId== cityId && x.IsActive==true).ToListAsync();
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            return await GetAsQueryable()
                .Include(x => x.PlaceFiles)
                .Include(x => x.City)
                .ToListAsync();
        }
    }
}
