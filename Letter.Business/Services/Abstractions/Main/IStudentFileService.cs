using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IStudentFileService
    {
        Task<ServiceResult> AddRangeAsync(AddStudentWordsDto studentWords, int id);
        Task<ServiceResult> UpdateRangeAsync(AddStudentWordsDto studentWords, int id);
    }
}
