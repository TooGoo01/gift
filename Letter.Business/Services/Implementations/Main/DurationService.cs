//using AutoMapper;
//using Letter.Business.Dtos.Get.Main;
//using Letter.Business.Dtos.Post.Main;
//using Letter.Business.Results;
//using Letter.Business.Services.Abstractions.Main;
//using Letter.DataAccess.Entities.Main;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using Letter.DataAccess.UnitOfWorks;


//namespace Letter.Business.Services.Implementations.Main
//{
//    public class DurationService : IDurationService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;
//        private readonly IDurationRepositoy _durationRepositoy;
//        private readonly IHomeRepository _universityRepository;

//        public DurationService(IUnitOfWork unitOfWork, IMapper mapper, IDurationRepositoy durationRepositoy, IHomeRepository universityRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _durationRepositoy = durationRepositoy;
//            _universityRepository = universityRepository;
//        }

//        public async Task<ServiceResult> AddDuration(AddDurationDto duration)
//        {
//            var result = _mapper.Map<Duration>(duration);
//            result.IsActive = true;
//            var university = await _universityRepository.GetUniverity(duration.UniversityId.Value);

//            int ifTrue = 0;

//            foreach (var item in university.Specialities)
//            {
//                if (item.Id == result.SpecialityId)
//                {
//                    ifTrue += 1;
//                }
//            }
//            foreach (var item in university.Programs)
//            {
//                if (item.Id == result.LetterProgramId)
//                {
//                    ifTrue += 1;
//                }
//            }
//            if (ifTrue >= 2)
//            {
//                await _unitOfWork.Repository<Duration>().AddAsync(result);
//                _unitOfWork.Commit();
//                var response = _mapper.Map<GetDurationDto>(result);
//                return new ServiceResult(true, response.Id);
//            }
//            return new ServiceResult(false, "invalid items according to duration");

//        }

//        public async Task<ServiceResult> DeleteDuration(int id)
//        {
//            var duration = await _durationRepositoy.GetDuration(id);
//            duration.IsActive = false;
//            _unitOfWork.Repository<Duration>().Update(duration);
//            _unitOfWork.Commit();
//            return new ServiceResult(true);
//        }

//        public async Task<ServiceResult> GetActiveDurations()
//        {
//            var result = await _durationRepositoy.GetActiveDurations();
//            var response = _mapper.Map<List<GetDurationDto>>(result);
//            return new ServiceResult(true, response); ;
//        }

//        public async Task<ServiceResult> GetDurationById(int id)
//        {
//            var result = await _durationRepositoy.GetDuration(id);
//            var response = _mapper.Map<GetDurationDto>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetDurationByProgram(int programId)
//        {
//            var result = await _durationRepositoy.GetDurationsByProgram(programId);
//            var response = _mapper.Map<List<GetDurationDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetDurationBySpeciality(int specialityId)
//        {
//            var result = await _durationRepositoy.GetDurationsBySpeciality(specialityId);
//            var response = _mapper.Map<List<GetDurationDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetDurationByUniveristyProgram(int univeristyId, int programId)
//        {
//            var result = await _durationRepositoy.GetDurationsByUniveristyProgram(univeristyId, programId);
//            var response = _mapper.Map<List<GetDurationDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetDurationByUniveristySpeciality(int univeristyId, int specialityId)
//        {
//            var result = await _durationRepositoy.GetDurationsByUniveristySpeciality(univeristyId, specialityId);
//            var response = _mapper.Map<List<GetDurationDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetDurationByUniversity(int universityId)
//        {
//            var result = await _durationRepositoy.GetDurationsByUniveristy(universityId);
//            var response = _mapper.Map<List<GetDurationDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAllDurations()
//        {
//            var result = await _durationRepositoy.GetDurations();
//            var response = _mapper.Map<List<GetDurationDto>>(result);
//            return new ServiceResult(true, response);
//        }


//        public async Task<ServiceResult> UpdateDuration(AddDurationDto durationDto, int id)
//        {
//            var result = await _durationRepositoy.GetDuration(id);
//            if (result != null)
//            {
//                if (durationDto.SpecialityId.HasValue)
//                {
//                    result.SpecialityId = durationDto.SpecialityId.Value;
//                }

//                if (durationDto.LetterProgramId.HasValue)
//                {
//                    result.LetterProgramId = durationDto.LetterProgramId.Value;
//                }

//                if (durationDto.UniversityId.HasValue)
//                {
//                    result.UniversityId = durationDto.UniversityId.Value;
//                }

//                if (!durationDto.DurationDateId.HasValue)
//                {
//                    result.DurationDateId = durationDto.DurationDateId.Value;
//                }

//                _unitOfWork.Repository<Duration>().Update(result);
//                var response = _mapper.Map<GetDurationDto>(result);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }
//    }
//}
