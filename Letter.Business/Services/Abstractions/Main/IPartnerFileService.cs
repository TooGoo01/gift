using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IPartnerFileService
    {
        Task<ServiceResult> AddRangeAsync(AddPartnerDto partner, int id);
        Task<ServiceResult> UpdateRangeAsync(AddPartnerDto partnerDto, int id);
    }
}
