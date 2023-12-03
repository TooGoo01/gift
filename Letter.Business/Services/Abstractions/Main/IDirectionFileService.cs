using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IDirectionFileService
    {
        Task<ServiceResult> AddRangeAsync(AddDirectionDto directionDto, int directionId);
        Task<ServiceResult> UpdateRangeAsync(AddDirectionDto directionDto, int directionId);
    }
}
