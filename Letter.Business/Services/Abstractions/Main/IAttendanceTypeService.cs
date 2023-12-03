using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IAttendanceTypeService
    {
        Task<ServiceResult> AddAttendanceType(AddAttendanceTypeDto attendanceType);
        Task<ServiceResult> UpdateAttendanceType(AddAttendanceTypeDto attendanceTypeDto, int id);
        Task<ServiceResult> GetAttendanceTypeById(int id);
        Task<ServiceResult> DeleteAttendanceType(int id);
        Task<ServiceResult> GetAttendanceTypes();
        Task<ServiceResult> GetActiveAttendanceTypes();
    }
}
