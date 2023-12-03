using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IAboutPageRepository : IGenericRepository<AboutPage>
    {
        Task<AboutPage> GetAboutPagePageById(int id);
        Task<AboutPage> GetLastAboutPagePage();
        Task<IEnumerable<AboutPage>> GetAllAboutPages();

    }
}
