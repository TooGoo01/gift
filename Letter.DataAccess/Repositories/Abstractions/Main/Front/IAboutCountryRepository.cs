using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IAboutCountryRepository : IGenericRepository<AboutCountry>
    {
        Task<AboutCountry> GetAboutCountrybyId(int id);
        Task<AboutCountry> GetLastAboutCountry();
        Task<IEnumerable<AboutCountry>> GetAllAboutCountries();

    }
}
