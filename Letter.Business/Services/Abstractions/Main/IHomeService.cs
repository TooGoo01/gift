using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main;

public interface IHomeService
{
    #region Get
    Task<ServiceResult> GetAllHomes();
    Task<ServiceResult> GetActiveHomes();
    Task<ServiceResult> GetHome(int homeId);
    Task<ServiceResult> GetHomesWithCityId(int cityId);
    Task<ServiceResult> GetHomesName();
    Task<ServiceResult> GetHomesTypeName(string typeName);
    Task<ServiceResult> GetHomesStatusId(int statusId);
    Task<ServiceResult> GetHomesByUserId();
    //Task<ServiceResult> GetRandomHomes();
    #endregion
    
    #region Post
    Task<ServiceResult> AddHome(AddHomeDto home);
    Task<ServiceResult> DeleteHomeById(int id);

    #endregion

    #region Search
    Task<ServiceResult> SearchHome(int currentPage, int pageSize, HomeSearchModelDto documentSearchModel);
    #endregion

    #region Put
    Task<ServiceResult> UpdateHome(UpdateHomeDto university, int id);

    #endregion
}
