using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IBlogFileService
    {
        Task<ServiceResult> AddRangeAsync(AddBlogDto blog, int blogId);
        Task<ServiceResult> UpdateRangeAsync(AddBlogDto blog, int blogId);
    }
}
