using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Main.Front;
using Letter.DataAccess.Repositories.Abstractions.Main.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Implementations.Main.Front
{
    public class GoStudyFrontFileRepository : GenericRepository<GoStudyFile>, IGoStudyFrontFileRepository
    {
        public GoStudyFrontFileRepository(LetterDbContext educationDbContext) : base(educationDbContext)
        {
        }
    }
}
