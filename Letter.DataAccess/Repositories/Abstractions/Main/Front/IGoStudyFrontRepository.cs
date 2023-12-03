using Letter.DataAccess.Entities.Main.Front;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IGoStudyFrontRepository : IGenericRepository<GoStudyFront>
    {
        Task<IEnumerable<GoStudyFront>> GetAllGoStudyFronts();
        Task<GoStudyFront> GetLastGoStudyFronts();
        Task<GoStudyFront> GetGoStudyFronts(int id);
    }
}
