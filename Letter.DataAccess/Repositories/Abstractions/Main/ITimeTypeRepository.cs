using Letter.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface ITimeTypeRepository
    {
        Task<List<TimeType>> GetAllTimeTypes();
        Task<List<TimeType>> GetActiveTimeTypes();
        Task<TimeType> GetTimeType(int id);
    }
}
