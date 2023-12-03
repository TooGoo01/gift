using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IIconRepository : IGenericRepository<Icon>
    {
        Task<IEnumerable<Icon>> GetIcons();
        Task<IEnumerable<Icon>> GetActiveIcons();
        Task<Icon> GetIcon(int iconId);
        
    }
}
