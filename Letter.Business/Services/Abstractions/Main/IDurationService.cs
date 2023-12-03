using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IDurationService
    {
        Task<ServiceResult> AddDuration(AddDurationDto duration);
        Task<ServiceResult> UpdateDuration(AddDurationDto durationDto, int id);
        Task<ServiceResult> GetDurationById(int id);
        Task<ServiceResult> GetDurationByUniversity(int universityId);
        Task<ServiceResult> GetDurationBySpeciality(int specialityId);
        Task<ServiceResult> GetDurationByProgram(int programId);
        Task<ServiceResult> GetDurationByUniveristySpeciality(int univeristyId, int specialityId);
        Task<ServiceResult> GetDurationByUniveristyProgram(int univeristyId, int programId);
        Task<ServiceResult> GetAllDurations();
        Task<ServiceResult> GetActiveDurations();
        Task<ServiceResult> DeleteDuration(int id);
    }
}
