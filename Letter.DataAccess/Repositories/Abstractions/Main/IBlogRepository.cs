using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<ICollection<Blog>> GetBlogs();
        Task<ICollection<Blog>> GetActiveBlogs();
        Task<Blog> GetBlog(int blogId);
        Task<ICollection<Blog>> GetActiveBlogsWithoutFile();
    }
}
