using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IAttendanceTypeRepository : IGenericRepository<AttendanceType>
    {
        Task<IEnumerable<AttendanceType>> GetAllAttendanceTypes();
        Task<IEnumerable<AttendanceType>> GetActiveAttendanceTypes();
        Task<AttendanceType> GetAttendanceType(int id);
    }
}
