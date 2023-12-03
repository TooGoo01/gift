using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Letter.DataAccess.UnitOfWorks;
using Microsoft.IdentityModel.Tokens;

namespace Letter.Business.Services.Implementations.Main
{
    public class TimeTypeService:ITimeTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITimeTypeRepository _typeRepository;

        public TimeTypeService(IUnitOfWork unitOfWork, IMapper mapper, ITimeTypeRepository typeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _typeRepository = typeRepository;
        }

        public async Task<ServiceResult> AddTimeType(AddTimeTypeDto type)
        {
            var request = _mapper.Map<TimeType>(type);
            request.IsActive = true;
            await _unitOfWork.Repository<TimeType>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetTimeTypeDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> DeleteTypeById(int typeId)
        {
            var type = await _typeRepository.GetTimeType(typeId);
            if (type != null)
            {
                type.IsActive = false;
                _unitOfWork.Repository<TimeType>().Update(type);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetTimeTypeDto>(type);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveTypes()
        {
            var types = await _typeRepository.GetActiveTimeTypes();
            if (types != null)
            {
                var response = _mapper.Map<List<GetTimeTypeDto>>(types);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetTypeId(int typeId)
        {
            var type = await _typeRepository.GetTimeType(typeId);
            if (type != null)
            {
                var response = _mapper.Map<GetTimeTypeDto>(type);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetTypes()
        {
            var types = await _typeRepository.GetAllTimeTypes();
            if (types != null)
            {
                var response = _mapper.Map<List<GetTimeTypeDto>>(types);
                //response.Files = _mapper.Map<GetFileDto>(blogs.ForEach(x => x.BlogFiles));
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateTimeType(AddTimeTypeDto typeDto, int id)
        {
            var type = await _typeRepository.GetTimeType(id);
            if (type != null)
            {
                if (!typeDto.AzName.IsNullOrEmpty())
                {
                    type.AzName = typeDto.AzName;
                }
                if (!typeDto.EnName.IsNullOrEmpty())
                {
                    type.EnName = typeDto.EnName;
                }
                if (!typeDto.RuName.IsNullOrEmpty())
                {
                    type.RuName = typeDto.RuName;
                }

                if (!typeDto.AzDescription.IsNullOrEmpty())
                {
                    type.AzDescription = typeDto.AzDescription;
                }
                if (!typeDto.EnDescription.IsNullOrEmpty())
                {
                    type.EnDescription = typeDto.EnDescription;
                }
                if (!typeDto.RuDescription.IsNullOrEmpty())
                {
                    type.RuDescription = typeDto.RuDescription;
                }

                _unitOfWork.Repository<TimeType>().Update(type);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetTimeTypeDto>(type);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
    }
}
