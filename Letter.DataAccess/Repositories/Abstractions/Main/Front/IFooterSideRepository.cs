using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IFooterSideRepository : IGenericRepository<FooterSide>
    {
        Task<FooterSide> GetFooterSideById(int id);
        Task<FooterSide> GetLastFooterSide();
        Task<IEnumerable<FooterSide>> GetAllFooterSides();

    }
}
