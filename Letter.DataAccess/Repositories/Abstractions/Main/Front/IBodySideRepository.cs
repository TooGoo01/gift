using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IBodySideRepository : IGenericRepository<BodySide>
    {
        Task<BodySide> GetBodySideById(int id);
        Task<BodySide> GetLastBodySide();
        Task<IEnumerable<BodySide>> GetAllBodySides();
    }
}
