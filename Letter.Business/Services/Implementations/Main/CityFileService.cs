using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Storage;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class CityFileService : ICityFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public CityFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }

        public async Task<ServiceResult> AddRangeAsync(AddCityDto countryDto, int contId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-city", countryDto.Files);
            var country = _unitOfWork.Repository<City>().Get(x => x.Id == contId);
            _unitOfWork.Repository<CityFile>().AddRange(result.Select(x => new CityFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                City = country

            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> UpdateRangeAsync(AddCityDto cityDto, int cityId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-city", cityDto.Files);
            var city = _unitOfWork.Repository<City>().Get(x => x.Id == cityId);
            var entity = await _unitOfWork.Repository<CityFile>().GetAllAsync(x => x.City.Id == cityId);
            _unitOfWork.Repository<CityFile>().DeleteRange(entity);
            _unitOfWork.Repository<CityFile>().UpdateRange(result.Select(x => new CityFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                City = city

            }));
            _unitOfWork.Commit();            //List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-city", countryDto.Files);
            return new ServiceResult(true);
        }
    }
}
