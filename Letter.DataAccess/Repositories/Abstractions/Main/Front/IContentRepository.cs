using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IContentRepository : IGenericRepository<Content>
    {
        Task<Content> GetContentById(int id);
        Task<Content> GetLastContent();
        Task<IEnumerable<Content>> GetAllContents();
    }
}
