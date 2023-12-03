using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IAboutFileService
    {
        Task<ServiceResult> AddRangeAsync(AddAboutDto about, int aboutId);
        Task<ServiceResult> UpdateRangeAsync(AddAboutDto aboutDto, int aboutId);
    }
}
