using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IDurationDateService
    {
        Task<ServiceResult> AddDurationDate(AddDurationDateDto durationDateDto);
        Task<ServiceResult> UpdateDurationDate(AddDurationDateDto durationDateDto, int id);
        Task<ServiceResult> GetDurationDate(int id);
        Task<ServiceResult> DeleteDurationDate(int id);
        Task<ServiceResult> GetAllDurationDate();
        Task<ServiceResult> GetActiveDurationDate();
    }
}
