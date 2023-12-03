using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IStudentWordsRepository : IGenericRepository<StudentWords>
    {
        Task<List<StudentWords>> GetAllStudentWords();
        Task<List<StudentWords>> GetActiveStudentWords();
        Task<StudentWords> GetStudentWords(int id);
        Task<List<StudentWords>> GetStudentWordsByCountry(int countryId);
    }
}
