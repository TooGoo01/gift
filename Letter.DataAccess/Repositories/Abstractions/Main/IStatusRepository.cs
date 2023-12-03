using Letter.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllStatus();
        Task<List<Status>> GetActiveStatus();
        Task<Status> GetFirstStatus();
        Task<Status> GetStatus(int id);
    }
}
