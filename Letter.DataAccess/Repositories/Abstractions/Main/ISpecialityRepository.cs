using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Models;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface ISpecialityRepository
    {
        Task<List<Speciality>> GetAllSpecialities();
        Task<List<Speciality>> GetActiveSpecialities();
        Task<Speciality> GetSpeciality(int id);
        Task<List<Speciality>> GetSpecialitiesViaDirection(int id);

        IQueryable<Speciality> SearcProduct(SpecialitySearchModel searchModel);
    }
}
