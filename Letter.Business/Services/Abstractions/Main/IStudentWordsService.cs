using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IStudentWordsService
    {
        Task<ServiceResult> GetActiveStudentWords();
        Task<ServiceResult> GetAllStudentWords();
        Task<ServiceResult> GetStudentWordsByCountryId(int countryId);
        Task<ServiceResult> GetStudentWords(int id);
        Task<ServiceResult> AddStudentWords(AddStudentWordsDto studentWords);
        Task<ServiceResult> UpdateStudentWords(AddStudentWordsDto studentWords, int id);
        Task<ServiceResult> DeleteStudentWords(int id);
    }
}
