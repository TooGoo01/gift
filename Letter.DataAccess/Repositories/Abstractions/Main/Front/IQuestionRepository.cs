using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<List<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(int id);
    }
}
