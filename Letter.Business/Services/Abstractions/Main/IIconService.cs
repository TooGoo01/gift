using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IIconService
    {
        #region Post
        Task<ServiceResult> AddIcon(AddIconDto icon);
        Task<ServiceResult> DeleteIconById(int iconId);
        Task<ServiceResult> UpdateIcon(AddIconDto iconDto, int id);
        #endregion

        #region Get
        Task<ServiceResult> GetIcon(int iconId);
        Task<ServiceResult> GetIcons();
        Task<ServiceResult> GetActiveIcons();
       

        #endregion
    }
}
