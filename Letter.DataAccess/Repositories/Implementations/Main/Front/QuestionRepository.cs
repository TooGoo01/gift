

using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }

    /*public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        public ProgramRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }
        public async Task<Program> GetProgram(int id)
        {
            return await GetAsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Program>> GetPrograms()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive)
                .ToListAsync();
        }
    }*/
}
