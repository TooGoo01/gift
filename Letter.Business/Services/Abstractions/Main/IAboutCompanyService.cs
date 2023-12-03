using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IAboutCompanyService
    {
        Task<ServiceResult> AddAboutCompany(AddAboutCompanyDto aboutCompanyDto);
        Task<ServiceResult> UpdateAboutCompany(AddAboutCompanyDto aboutCompanyDto, int id);
        Task<ServiceResult> DeleteAboutCompany(int id);
        Task<ServiceResult> GetAboutCompany(int id);
        Task<ServiceResult> GetAllAboutCompanies();
        Task<ServiceResult> GetActiveAboutCompanies();
        Task<ServiceResult> GetLastAboutCompany();
    }
}
