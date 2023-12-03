using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Letter.DataAccess.Repositories.Implementations.Main;
using Letter.DataAccess.UnitOfWorks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Implementations.Main
{
   
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> AddPlace(AddPlaceDto place)
        {
            var request = _mapper.Map<Place>(place);
            request.IsActive = true;
            await _unitOfWork.Repository<Place>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetPlaceDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeletePlaceById(int placeId)
        {
            var place = await _placeRepository.GetPlace(placeId);
            if (place != null)
            {
                place.IsActive = false;
                _unitOfWork.Repository<Place>().Update(place);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetPlaceDto>(place);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActivePlaces()
        {
            var request = await _placeRepository.GetActivePlaces();
            var response = _mapper.Map<IEnumerable<GetPlaceDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPlace(int placeId)
        {
            var request = await _placeRepository.GetPlace(placeId);

            var response = _mapper.Map<GetPlaceDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPlaces()
        {
            var request = await _placeRepository.GetPlaces();
            var response = _mapper.Map<List<GetPlaceDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPlacesByCityId(int cityId)
        {
            var request = await _placeRepository.GetPlaceByCityId(cityId);
            var response = _mapper.Map<List<GetPlaceDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdatePlace(AddPlaceDto placeDto, int id)
        {
            var place = await _placeRepository.GetPlace(id);
            if (place != null)
            {
                if (!placeDto.AzTitle.IsNullOrEmpty())
                {
                    place.AzTitle = placeDto.AzTitle;
                }
                if (!placeDto.EnTitle.IsNullOrEmpty())
                {
                    placeDto.EnTitle = placeDto.EnTitle;
                }
                if (!placeDto.RuTitle.IsNullOrEmpty())
                {
                    place.RuTitle = placeDto.RuTitle;

                }
                if (!placeDto.AzDescription.IsNullOrEmpty())
                {
                    place.AzDescription = placeDto.AzDescription;
                }
                if (!placeDto.EnDescription.IsNullOrEmpty())
                {
                    place.EnDescription = placeDto.EnDescription;

                }
                if (!placeDto.RuDescription.IsNullOrEmpty())
                {
                    place.RuDescription = placeDto.RuDescription;
                }

                if (placeDto.CityId != null)
                {
                    place.cityId = placeDto.CityId.Value;
                }

                _unitOfWork.Repository<Place>().Update(place);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetPlaceDto>(place);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }
    }
}
