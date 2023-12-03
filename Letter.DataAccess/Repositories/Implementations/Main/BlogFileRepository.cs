using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;

namespace Letter.DataAccess.Repositories.Implementations.Main
{
    public class BlogFileRepository : GenericRepository<BlogFile>, IBlogFileRepository
    {
        public BlogFileRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {

        }
    }
}
