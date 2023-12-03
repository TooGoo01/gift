using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IStudentRequestService
    {
        #region Post
        Task<ServiceResult> AddStudentRequest(AddStudentRequestDto studentRequest);
        Task<ServiceResult> DeleteRequestById(int requestId);
        Task<ServiceResult> MakeSeenRequest(int id);

        #endregion

        #region Get
        Task<ServiceResult> GetRequests();
        Task<ServiceResult> GetActiveRequests();
        Task<ServiceResult> GetRequest(int id);
        Task<ServiceResult> GetLastStudentRequest();
        Task<ServiceResult> GetSeenStudentRequests();
        Task<ServiceResult> GetNonSeenStudentRequests();

        #endregion

        Task<ServiceResult> ExportToExcel();
    }
}
