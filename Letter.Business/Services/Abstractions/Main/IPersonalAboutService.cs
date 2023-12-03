using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IPersonalAboutService
    {
        Task<ServiceResult> GetPersonalAbouts();
        Task<ServiceResult> AddPersonalAbouts(AddPersonalAbout about);
        Task<ServiceResult> DeletePersonalAboutById(int aboutId);
    }
}
