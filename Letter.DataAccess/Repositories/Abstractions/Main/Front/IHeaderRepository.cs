using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IHeaderRepository : IGenericRepository<Header>
    {
        Task<Header> GetHeader(int id);
        Task<IEnumerable<Header>> GetHeaders();
        Task<IEnumerable<Header>> GetActiveHeaders();
    }
}
