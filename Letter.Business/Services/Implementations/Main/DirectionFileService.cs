using AutoMapper;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Storage;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class DirectionFileService : IDirectionFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public DirectionFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddDirectionDto directionDto, int directionId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-direction", directionDto.Files);
            var direction = _unitOfWork.Repository<Direction>().Get(x => x.Id == directionId);
            _unitOfWork.Repository<DirectionFile>().AddRange(result.Select(x => new DirectionFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Direction = direction

            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> UpdateRangeAsync(AddDirectionDto directionDto, int directionId)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-direction", directionDto.Files);
            var direction = _unitOfWork.Repository<Direction>().Get(x => x.Id == directionId);
            var entity = await _unitOfWork.Repository<DirectionFile>().GetAllAsync(x => x.Direction.Id == directionId);
            _unitOfWork.Repository<DirectionFile>().DeleteRange(entity);
            _unitOfWork.Repository<DirectionFile>().UpdateRange(result.Select(x => new DirectionFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Direction = direction
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}
