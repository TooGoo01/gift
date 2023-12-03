using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IBlogFrontRepository : IGenericRepository<BlogFront>
    {
        Task<IEnumerable<BlogFront>> GetAllBlogFront();
        Task<BlogFront> GetBlogFront(int id);
        Task<BlogFront> GetLastBlogFront();
    }
}
