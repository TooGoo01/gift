using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IPartnerRepository : IGenericRepository<Partner>
    {
        Task<IEnumerable<Partner>> GetAllPartners();
        Task<IEnumerable<Partner>> GetActivePartners();
        Task<Partner> GetPartner(int id);
    }
}
