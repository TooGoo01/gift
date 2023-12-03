using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IAttendanceService
    {
        Task<ServiceResult> AddAttendance(AddAttendanceDto attendance);
        Task<ServiceResult> UpdateAttendance(AddAttendanceDto attendanceDto, int id);
        Task<ServiceResult> GetAttendanceById(int id);
        Task<ServiceResult> GetDeleteAttendance(int id);
        Task<ServiceResult> GetAttendanceByUniversity(int universityId);
        Task<ServiceResult> GetAttendanceBySpeciality(int specialityId);
        Task<ServiceResult> GetAttendanceByProgram(int programId);
        Task<ServiceResult> GetAttendanceByUniveristySpeciality(int univeristyId, int specialityId);
        Task<ServiceResult> GetAttendanceByUniveristyProgram(int univeristyId, int programId);
        Task<ServiceResult> GetAttendances();
        Task<ServiceResult> GetActiveAttendances();
    }
}
