using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IPlaceFileService
    {
        Task<ServiceResult> AddRangeAsync(AddPlaceDto place, int placeId);
        Task<ServiceResult> UpdateRangeAsync(AddPlaceDto place, int placeId);
    }
}
