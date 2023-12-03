        using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Models;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IHomeRepository : IGenericRepository<Home>
    {
        Task<List<Home>> GetAllHomes();
        Task<List<Home>> GetActiveHomes();
        Task<Home> GetHome(int uniId);
        Task<List<Home>> GetHomeByUserId(int userId);
        Task<List<Home>> GetHomesByCity(int countryId);
        Task<List<Home>> GetHomesByTypeName(string typeName);
        Task<List<Home>> GetHomesByStatusId(int statusId);
        IQueryable<Home> SearcHome(HomeSearchModel searchModel);
        Task<List<Home>> GetActiveHomesName();
        Task<IEnumerable<Home>> GetRandomActiveHomes();
    }
}
