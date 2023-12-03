using Letter.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IPlaceRepository : IGenericRepository<Place>
    {
        Task<IEnumerable<Place>> GetPlaces();
        Task<IEnumerable<Place>> GetActivePlaces();
        Task<Place> GetPlace(int placeId);
        Task<IEnumerable<Place>> GetPlaceByCityId(int cityId);
        
    }
}
