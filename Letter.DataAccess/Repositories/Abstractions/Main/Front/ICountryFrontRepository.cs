using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface ICountryFrontRepository : IGenericRepository<CountryFront>
    {
        Task<IEnumerable<CountryFront>> GetAllCountryFronts();
        Task<CountryFront> GetLastCountryFronts();
        Task<CountryFront> GetCountryFronts(int id);
    }
}
