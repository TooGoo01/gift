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
//    public class AttendanceService : IAttendanceService
//    {
//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IAttendanceRepository _attendanceRepository;
//        private readonly IHomeRepository _universityRepository;

//        public AttendanceService(IMapper mapper, IUnitOfWork unitOfWork, IAttendanceRepository attendanceRepository, IHomeRepository universityRepository)
//        {
//            _mapper = mapper;
//            _unitOfWork = unitOfWork;
//            _attendanceRepository = attendanceRepository;
//            _universityRepository = universityRepository;
//        }

//        public async Task<ServiceResult> AddAttendance(AddAttendanceDto attendance)
//        {
//            var result = _mapper.Map<Attendance>(attendance);
//            result.IsActive = true;

//            var university = await _universityRepository.GetUniverity(attendance.UniversityId.Value);

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
//            if (ifTrue == 2)
//            {
//                await _unitOfWork.Repository<Attendance>().AddAsync(result);
//                _unitOfWork.Commit();
//                var response = _mapper.Map<GetAttendanceDto>(result);
//                return new ServiceResult(true, response.Id);
//            }
//            return new ServiceResult(false, "invalid items according to university");
//        }

//        public async Task<ServiceResult> GetAttendanceById(int id)
//        {
//            var result = await _attendanceRepository.GetAttendance(id);
//            var response = _mapper.Map<GetAttendanceDto>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendanceByProgram(int programId)
//        {
//            var result = await _attendanceRepository.GetAttendancesByProgram(programId);
//            var response = _mapper.Map<List<GetAttendanceDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendanceByUniveristyProgram(int univeristyId, int programId)
//        {
//            var result = await _attendanceRepository.GetAttendancesByUniveristyProgram(univeristyId, programId);
//            var response = _mapper.Map<List<GetAttendanceDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendanceByUniveristySpeciality(int univeristyId, int specialityId)
//        {
//            var result = await _attendanceRepository.GetAttendancesByUniveristySpeciality(univeristyId, specialityId);
//            var response = _mapper.Map<List<GetAttendanceDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendanceByUniversity(int universityId)
//        {
//            var result = await _attendanceRepository.GetAttendancesByUniveristy(universityId);
//            var response = _mapper.Map<List<GetAttendanceDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendances()
//        {
//            var result = await _attendanceRepository.GetAttendances();
//            var response = _mapper.Map<List<GetAttendanceDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendanceBySpeciality(int specialityId)
//        {
//            var result = await _attendanceRepository.GetAttendancesBySpeciality(specialityId);
//            var response = _mapper.Map<List<GetAttendanceDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> UpdateAttendance(AddAttendanceDto attendanceDto, int id)
//        {
//            var result = await _attendanceRepository.GetAttendance(id);
//            if (result != null)
//            {
//                if (attendanceDto.AttendanceTypeId.HasValue)
//                {
//                    result.AttendanceTypeId = attendanceDto.AttendanceTypeId.Value;
//                }

//                if (attendanceDto.SpecialityId.HasValue)
//                {
//                    result.SpecialityId = attendanceDto.SpecialityId.Value;
//                }

//                if (attendanceDto.LetterProgramId.HasValue)
//                {
//                    result.LetterProgramId = attendanceDto.LetterProgramId.Value;
//                }

//                if (attendanceDto.UniversityId.HasValue)
//                {
//                    result.UniversityId = attendanceDto.UniversityId.Value;
//                }
//                _unitOfWork.Repository<Attendance>().Update(result);
//                var response = _mapper.Map<GetAttendanceDto>(result);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> GetDeleteAttendance(int id)
//        {
//            var result = await _attendanceRepository.GetAttendance(id);
//            if (result != null)
//            {
//                result.IsActive = false;
//                _unitOfWork.Repository<Attendance>().Update(result);
//                _unitOfWork.Commit();
//                return new ServiceResult(true);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> GetActiveAttendances()
//        {
//            var result = await _attendanceRepository.GetActiveAttendances();
//            var response = _mapper.Map<List<GetAttendanceDto>>(result);
//            return new ServiceResult(true, response);
//        }
//    }
//}
