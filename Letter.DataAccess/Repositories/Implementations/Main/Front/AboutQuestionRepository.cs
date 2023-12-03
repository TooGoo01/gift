using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using Microsoft.EntityFrameworkCore;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class AboutQuestionRepository : GenericRepository<AboutQuestion>, IAboutQuestionRepository
    {
        public AboutQuestionRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }

        public async Task<AboutQuestion> GetAboutQuestionById(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.Questions.AsQueryable())
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutQuestion> GetLastAboutQuestion()
        {
            return await GetAsQueryable()
                .OrderBy(x => x.Id)
                .Include(x => x.Questions.AsQueryable())
                .LastOrDefaultAsync();
        }

        public async Task<IEnumerable<AboutQuestion>> GetAllAboutQuestions()
        {
            return await GetAsQueryable()
                .Include(x => x.Questions.AsQueryable())
                .ToListAsync();
        }
    }
}
