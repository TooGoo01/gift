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
    public class DurationDateService : IDurationDateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDurationDateRepository _durationDateRepository;

        public DurationDateService(IUnitOfWork unitOfWork, IMapper mapper, IDurationDateRepository durationDateRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _durationDateRepository = durationDateRepository;
        }
        public async Task<ServiceResult> AddDurationDate(AddDurationDateDto durationDateDto)
        {
            var request = _mapper.Map<DurationDate>(durationDateDto);
            request.IsActive = true;
            await _unitOfWork.Repository<DurationDate>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetDurationDateDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> DeleteDurationDate(int id)
        {
            var date = await _durationDateRepository.GetDurationDate(id);
            if (date != null)
            {
                date.IsActive = false;
                _unitOfWork.Repository<DurationDate>().Update(date);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveDurationDate()
        {
            var result = await _durationDateRepository.GetActiveDurationDates();
            if (result == null)
                return new ServiceResult(false, "data not found");

            var response = _mapper.Map<List<GetDurationDateDto>>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetAllDurationDate()
        {
            var result = await _durationDateRepository.GetAllDurationDates();
            if (result == null)
                return new ServiceResult(false, "data not found");

            var response = _mapper.Map<List<GetDurationDateDto>>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetDurationDate(int id)
        {
            var result = await _durationDateRepository.GetDurationDate(id);
            if (result == null)
                return new ServiceResult(false, "data not found");

            var response = _mapper.Map<GetDurationDateDto>(result);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateDurationDate(AddDurationDateDto durationDateDto, int id)
        {
            var date = await _durationDateRepository.GetDurationDate(id);
            if (date != null)
            {
                if (!durationDateDto.Date.IsNullOrEmpty())
                {
                    date.Date = durationDateDto.Date;
                }
                _unitOfWork.Repository<DurationDate>().Update(date);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetDurationDateDto>(date);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);

        }
    }
}
