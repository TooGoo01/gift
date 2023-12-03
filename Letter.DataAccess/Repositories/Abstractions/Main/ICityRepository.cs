          using Letter.Business.Dtos.Get.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface ICityRepository : IGenericRepository<City>
    {
        //Task<IEnumerable<City>> GetRandomActiveCountries();
        Task<IEnumerable<City>> GetActiveCities();
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCity(int cityId);

        Task<IEnumerable<City>> GetDeActiveCities();
        //object GetCountriesIdName();
    }
}
