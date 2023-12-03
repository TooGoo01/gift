using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface ICityService
    {
        #region Post
        Task<ServiceResult> AddCity(AddCityDto city);
        Task<ServiceResult> ActivateCity(int cityId);
        #endregion

        #region Get
        Task<ServiceResult> GetAllCities();
        Task<ServiceResult> GetAllCitiesIdName();
        Task<ServiceResult> GetActiveCities();
        Task<ServiceResult> GetDeActiveCities();
        Task<ServiceResult> GetCity(int cityId);
        Task<ServiceResult> GetRandomActiveCities();
        #endregion
        Task<ServiceResult> UpdateCity(AddCityDto cityDto, int id);
        Task<ServiceResult> SearchCity(int currentPage, int pageSize);
        Task<ServiceResult> DeleteCity(int id);
    }
}
