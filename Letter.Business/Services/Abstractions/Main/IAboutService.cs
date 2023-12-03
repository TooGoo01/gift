using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IAboutService
    {
        #region Get
        Task<ServiceResult> GetAbouts();
        Task<ServiceResult> GetActiveAbouts();
        Task<ServiceResult> GetAbout(int aboutId);

        #endregion
        #region Post
        Task<ServiceResult> AddAbouts(AddAboutDto about);
        Task<ServiceResult> UpdateAbout(AddAboutDto about, int id);
        Task<ServiceResult> DeleteAboutById(int aboutId);

        #endregion
    }
}
