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
    public class DirectionService : IDirectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDirectionRepository _directionRepository;

        public DirectionService(IUnitOfWork unitOfWork, IMapper mapper, IDirectionRepository directionRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _directionRepository = directionRepository;
        }
        public async Task<ServiceResult> AddDirection(AddDirectionDto direction)
        {
            var request = _mapper.Map<Direction>(direction);
            request.IsActive = true;

            await _unitOfWork.Repository<Direction>().AddAsync(request);
            _unitOfWork.Commit();

            var response = _mapper.Map<GetDirectionDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeleteDirectionById(int id)
        {
            var direction = await _directionRepository.GetDirection(id);
            if (direction != null)
            {
                direction.IsActive = false;
                _unitOfWork.Repository<Direction>().Update(direction);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetDirectionDto>(direction);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetDirection(int id)
        {
            var result = await _directionRepository.GetDirection(id);
            if (result == null)
                return new ServiceResult(false, "data not found");

            var response = _mapper.Map<GetDrectionWithUniversityDto>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetAllDirections()
        {
            var result = await _directionRepository.GetAllDirections();
            if (result == null)
            {
                return new ServiceResult(false, "data not found");
            }
            var response = _mapper.Map<List<GetDirectionDto>>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetActiveDirections()
        {
            var result = await _directionRepository.GetActiveDirections();
            if (result == null)
            {
                return new ServiceResult(false, "data not found");
            }
            var response = _mapper.Map<List<GetDirectionDto>>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetActiveDirectionsOrderAz()
        {
            var result = await _directionRepository.GetActiveDirectionsOrderAzName();
            if (result == null)
            {
                return new ServiceResult(false, "data not found");
            }
            var response = _mapper.Map<List<GetDirectionDto>>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetActiveDirectionsOrderEn()
        {
            var result = await _directionRepository.GetActiveDirectionsOrderEnName();
            if (result == null)
            {
                return new ServiceResult(false, "data not found");
            }
            var response = _mapper.Map<List<GetDirectionDto>>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetActiveDirectionsOrderRu()
        {
            var result = await _directionRepository.GetActiveDirectionsOrderRuName();
            if (result == null)
            {
                return new ServiceResult(false, "data not found");
            }
            var response = _mapper.Map<List<GetDirectionDto>>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateDirection(AddDirectionDto directionDto, int id)
        {
            var direction = await _directionRepository.GetDirection(id);
            if (direction != null)
            {
                if (!directionDto.AzName.IsNullOrEmpty())
                {
                    direction.AzName = directionDto.AzName;
                }
                if (!directionDto.EnName.IsNullOrEmpty())
                {
                    direction.EnName = directionDto.EnName;
                }
                if (!directionDto.RuName.IsNullOrEmpty())
                {
                    direction.RuName = directionDto.RuName;
                }

                if (!directionDto.AzDescription.IsNullOrEmpty())
                {
                    direction.AzDescription = directionDto.AzDescription;
                }
                if (!directionDto.EnDescription.IsNullOrEmpty())
                {
                    direction.EnDescription = directionDto.EnDescription;
                }
                if (!directionDto.RuDescription.IsNullOrEmpty())
                {
                    direction.RuDescription = directionDto.RuDescription;
                }
                _unitOfWork.Repository<Direction>().Update(direction);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetDirectionDto>(direction);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }
    }
}
