using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IAboutQuestionRepository : IGenericRepository<AboutQuestion>
    {
        Task<AboutQuestion> GetAboutQuestionById(int id);
        Task<AboutQuestion> GetLastAboutQuestion();
        Task<IEnumerable<AboutQuestion>> GetAllAboutQuestions();
    }
}
