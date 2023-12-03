using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class CountryFileRepository : GenericRepository<CityFile>, ICountryFileRepository
    {
        public CountryFileRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }
    }
}
