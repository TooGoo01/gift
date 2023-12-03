using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IDirectionService
    {
        #region Get
        Task<ServiceResult> GetAllDirections();
        Task<ServiceResult> GetActiveDirections();
        Task<ServiceResult> GetActiveDirectionsOrderAz();
        Task<ServiceResult> GetActiveDirectionsOrderEn();
        Task<ServiceResult> GetActiveDirectionsOrderRu();
        Task<ServiceResult> GetDirection(int id);

        #endregion
        #region Post
        Task<ServiceResult> AddDirection(AddDirectionDto direction);
        Task<ServiceResult> DeleteDirectionById(int id);
        Task<ServiceResult> UpdateDirection(AddDirectionDto directionDto, int id);
        #endregion

    }
}
