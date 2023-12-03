using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IDurationDateRepository : IGenericRepository<DurationDate>
    {
        Task<DurationDate> GetDurationDate(int id);
        Task<IEnumerable<DurationDate>> GetAllDurationDates();
        Task<IEnumerable<DurationDate>> GetActiveDurationDates();
    }
}
