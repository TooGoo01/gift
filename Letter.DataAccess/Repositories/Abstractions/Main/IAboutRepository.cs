using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IAboutRepository : IGenericRepository<About>
    {
        Task<List<About>> GetAbouts();
        Task<List<About>> GetActiveAbouts();
        Task<About> GetAbout(int aboutId);
    }
}
