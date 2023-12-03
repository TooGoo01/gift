using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IPlaceService
    {
        #region Post
        Task<ServiceResult> AddPlace(AddPlaceDto place);
        Task<ServiceResult> DeletePlaceById(int placeId);
        Task<ServiceResult> UpdatePlace(AddPlaceDto placeDto, int id);
        #endregion

        #region Get
        Task<ServiceResult> GetPlace(int placeId);
        Task<ServiceResult> GetPlaces();
        Task<ServiceResult> GetActivePlaces();
        Task<ServiceResult> GetPlacesByCityId(int cityId);
       
        #endregion
    }
}
