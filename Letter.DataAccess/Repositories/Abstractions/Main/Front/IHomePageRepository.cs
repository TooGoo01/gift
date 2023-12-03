using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IHomePageRepository : IGenericRepository<HomePage>
    {
        Task<HomePage> GetHomePageById(int id);
        Task<HomePage> GetLastHomePage();
        Task<IEnumerable<HomePage>> GetAllHomePages();
    }
}
