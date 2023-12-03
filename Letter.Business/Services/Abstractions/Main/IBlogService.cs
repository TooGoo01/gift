using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IBlogService
    {
        #region Post
        Task<ServiceResult> AddBlog(AddBlogDto blog);
        Task<ServiceResult> DeleteBlogById(int blogId);
        Task<ServiceResult> UpdateBlog(AddBlogDto blogDto, int id);
        #endregion

        #region Get
        Task<ServiceResult> GetBlog(int blogId);
        Task<ServiceResult> GetBlogs();
        Task<ServiceResult> GetActiveBlogs();
        Task<ServiceResult> GetActiveBlogsWithouttFile();
        #endregion
    }
}
