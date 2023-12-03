using Letter.DataAccess.Entities.Main.Front;


namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IDirectionFrontRepository : IGenericRepository<DirectionFront>
    {
        Task<IEnumerable<DirectionFront>> GetAllDirectionFront();
        Task<DirectionFront> GetDirectionFront(int id);
        Task<DirectionFront> GetLastDirectionFront();
    }
}
