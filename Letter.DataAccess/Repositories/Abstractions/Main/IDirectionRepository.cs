using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IDirectionRepository
    {
        Task<ICollection<Direction>> GetAllDirections();
        Task<Direction> GetDirection(int id);
        Task<ICollection<Direction>> GetActiveDirections();
        Task<ICollection<Direction>> GetActiveDirectionsOrderAzName();
        Task<ICollection<Direction>> GetActiveDirectionsOrderEnName();
        Task<ICollection<Direction>> GetActiveDirectionsOrderRuName();
    }
}
