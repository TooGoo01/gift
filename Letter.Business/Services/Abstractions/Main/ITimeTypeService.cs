using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface ITimeTypeService
    {
        #region Post
        Task<ServiceResult> AddTimeType(AddTimeTypeDto type);
        Task<ServiceResult> UpdateTimeType(AddTimeTypeDto type, int id);
        Task<ServiceResult> DeleteTypeById(int typeId);

        #endregion

        #region Get
        Task<ServiceResult> GetTypes();
        Task<ServiceResult> GetActiveTypes();
        Task<ServiceResult> GetTypeId(int typeId);

        #endregion
    }
}
