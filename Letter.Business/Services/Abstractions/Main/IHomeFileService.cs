using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IHomeFileService
    {
        Task<ServiceResult> AddRangeAsync(AddHomeDto home, int uniId);
        Task<ServiceResult> UpdateRangeAsync(UpdateHomeDto home, int uniId);
    }
}
