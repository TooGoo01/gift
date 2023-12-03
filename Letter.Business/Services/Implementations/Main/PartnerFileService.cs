using AutoMapper;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Storage;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class PartnerFileService : IPartnerFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public PartnerFileService(IUnitOfWork unitOfWork, IStorage storage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _storage = storage;
            _mapper = mapper;
        }
        public async Task<ServiceResult> AddRangeAsync(AddPartnerDto partnerDto, int id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-patner", partnerDto.Files);
            var partner = _unitOfWork.Repository<Partner>().Get(x => x.Id == id);
            _unitOfWork.Repository<PartnerFile>().AddRange(result.Select(x => new PartnerFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Partner = partner

            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> UpdateRangeAsync(AddPartnerDto partnerDto, int id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storage.UploadAsync("photo-patner", partnerDto.Files);
            var partner = _unitOfWork.Repository<Partner>().Get(x => x.Id == id);
            var entity = await _unitOfWork.Repository<PartnerFile>().GetAllAsync(x => x.Partner.Id == id);
            _unitOfWork.Repository<PartnerFile>().DeleteRange(entity);
            _unitOfWork.Repository<PartnerFile>().UpdateRange(result.Select(x => new PartnerFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Partner = partner
            }));
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }
    }
}