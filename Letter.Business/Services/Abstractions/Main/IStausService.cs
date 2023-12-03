using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IStausService
    {
        #region Post
        Task<ServiceResult> AddStatus(AddStatusDto status);
        Task<ServiceResult> UpdateStatus(AddStatusDto status, int id);
        Task<ServiceResult> DeleteStatus(int statusId);

       #endregion
        #region Get
        Task<ServiceResult> GetStatuses();
        Task<ServiceResult> GetActiveStatuses();
        Task<ServiceResult> GetStatusId(int statusId);
        #endregion
    }
}
