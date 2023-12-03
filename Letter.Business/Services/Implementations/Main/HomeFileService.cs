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
    public class HomeFileService : IHomeFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public HomeFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddHomeDto homeDto, int homeId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-home", homeDto.Files);
            var home = _unitOfWork.Repository<Home>().Get(x => x.Id == homeId);
            _unitOfWork.Repository<HomeFile>().AddRange(result.Select(x => new HomeFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Home =home
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }


        public async Task<ServiceResult> UpdateRangeAsync(UpdateHomeDto homeDto, int uniId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-university", homeDto.Files);

            var home = _unitOfWork.Repository<Home>().Get(x => x.Id == uniId);
            var entity = await _unitOfWork.Repository<HomeFile>().GetAllAsync(x => x.Home.Id == uniId);
            _unitOfWork.Repository<HomeFile>().DeleteRange(entity);

            _unitOfWork.Repository<HomeFile>().UpdateRange(result.Select(x => new HomeFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Home = home
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}
