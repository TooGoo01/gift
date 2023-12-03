using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IHomeTypeRepository
    {
        Task<List<HomeType>> GetAllTypes();
        Task<List<HomeType>> GetActiveTypes();
        Task<HomeType> GetType(int id);
    }
}
