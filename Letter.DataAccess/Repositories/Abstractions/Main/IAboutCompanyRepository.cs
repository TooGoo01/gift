using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IAboutCompanyRepository : IGenericRepository<AboutCompany>
    {
        Task<List<AboutCompany>> GetActiveAboutCompanies();
        Task<AboutCompany> GetAboutCompany(int id);
        Task<List<AboutCompany>> GetAllAboutCompanies();
        Task<AboutCompany> GetLastAboutCompany();
    }
}
