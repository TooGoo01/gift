using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IPartnerFrontRepository : IGenericRepository<PartnerFront>
    {
        Task<IEnumerable<PartnerFront>> GetAllPartnersFront();
        Task<PartnerFront> GetPartnerFront(int id);
        Task<PartnerFront> GetLastPartnerFront();
    }
}
