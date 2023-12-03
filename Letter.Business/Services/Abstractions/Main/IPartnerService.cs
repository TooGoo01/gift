using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IPartnerService
    {
        Task<ServiceResult> AddPartner(AddPartnerDto partner);
        Task<ServiceResult> GetPartners();
        Task<ServiceResult> GetActivePartners();
        Task<ServiceResult> GetPartner(int id);
        Task<ServiceResult> UpdatePartner(AddPartnerDto partnerDto, int id);
        Task<ServiceResult> DeletePartner(int id);
    }
}
