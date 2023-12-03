using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Storage;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Implementations.Main
{
    public class PlaceFileService : IPlaceFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public PlaceFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }

        public async Task<ServiceResult> AddRangeAsync(AddPlaceDto place, int placeId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-place", place.Files);
            var places = _unitOfWork.Repository<Place>().Get(x => x.Id == placeId);
            _unitOfWork.Repository<PlaceFile>().AddRange(result.Select(x => new PlaceFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Places = places
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> UpdateRangeAsync(AddPlaceDto place, int placeId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-place", place.Files);

            var places = _unitOfWork.Repository<Place>().Get(x => x.Id == placeId);
            var entity = await _unitOfWork.Repository<PlaceFile>().GetAllAsync(x => x.Places.Id == placeId);
            _unitOfWork.Repository<PlaceFile>().DeleteRange(entity);

            _unitOfWork.Repository<PlaceFile>().UpdateRange(result.Select(x => new PlaceFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Places = places
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}
