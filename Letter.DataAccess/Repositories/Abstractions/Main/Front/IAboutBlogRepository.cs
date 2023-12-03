using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IAboutBlogRepository : IGenericRepository<AboutBlog>
    {
        Task<AboutBlog> GetAboutBlogById(int id);
        Task<AboutBlog> GetLastAboutBlog();
        Task<IEnumerable<AboutBlog>> GetAllAboutBlogs();

    }
}
