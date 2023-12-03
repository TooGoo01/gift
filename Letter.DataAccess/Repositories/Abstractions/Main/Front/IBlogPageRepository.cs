using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IBlogPageRepository : IGenericRepository<BlogPage>
    {
        Task<BlogPage> GetBlogPageById(int id);
        Task<BlogPage> GetLastBlogPage();
        Task<IEnumerable<BlogPage>> GetAllBlogPages();
    }
}
