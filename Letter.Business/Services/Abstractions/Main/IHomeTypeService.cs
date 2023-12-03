using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IHomeTypeService
    {
        #region Post
        Task<ServiceResult> AddType(AddHomeTypeDto type);
        Task<ServiceResult> UpdateType(AddHomeTypeDto type, int id);
        Task<ServiceResult> DeleteTypeById(int typeId);

        #endregion

        #region Get
        Task<ServiceResult> GetTypes();
        Task<ServiceResult> GetActiveTypes();
        Task<ServiceResult> GetTypeId(int typeId);

        #endregion
    }
}
