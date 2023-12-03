//using AutoMapper;
//using Letter.Business.Dtos.Get.Main;
//using Letter.Business.Dtos.Post.Main;
//using Letter.Business.Results;
//using Letter.Business.Services.Abstractions.Main;
//using Letter.DataAccess.Entities.Main;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using Letter.DataAccess.UnitOfWorks;
//using Microsoft.IdentityModel.Tokens;

//namespace Letter.Business.Services.Implementations.Main
//{
//    public class AttendanceTypeService : IAttendanceTypeService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;
//        private readonly IAttendanceTypeRepository _attendanceTypeRepository;

//        public AttendanceTypeService(IUnitOfWork unitOfWork, IMapper mapper, IAttendanceTypeRepository attendanceTypeRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _attendanceTypeRepository = attendanceTypeRepository;
//        }

//        public async Task<ServiceResult> AddAttendanceType(AddAttendanceTypeDto attendanceType)
//        {
//            var request = _mapper.Map<AttendanceType>(attendanceType);
//            request.IsActive = true;
//            await _unitOfWork.Repository<AttendanceType>().AddAsync(request);
//            _unitOfWork.Commit();
//            var response = _mapper.Map<GetAttendanceTypeDto>(request);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> DeleteAttendanceType(int id)
//        {
//            var type = await _attendanceTypeRepository.GetAttendanceType(id);
//            if (type != null)
//            {
//                type.IsActive = false;
//                _unitOfWork.Repository<AttendanceType>().Update(type);
//                _unitOfWork.Commit();
//                return new ServiceResult(true);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> GetActiveAttendanceTypes()
//        {
//            var result = await _attendanceTypeRepository.GetActiveAttendanceTypes();
//            var response = _mapper.Map<List<GetAttendanceTypeDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendanceTypeById(int id)
//        {
//            var result = await _attendanceTypeRepository.GetAttendanceType(id);
//            var response = _mapper.Map<GetAttendanceTypeDto>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> GetAttendanceTypes()
//        {
//            var result = await _attendanceTypeRepository.GetAllAttendanceTypes();
//            var response = _mapper.Map<List<GetAttendanceTypeDto>>(result);
//            return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> UpdateAttendanceType(AddAttendanceTypeDto attendanceTypeDto, int id)
//        {
//            var result = await _attendanceTypeRepository.GetAttendanceType(id);
//            if (result != null)
//            {
//                if (!attendanceTypeDto.Title.IsNullOrEmpty())
//                {
//                    result.Title = attendanceTypeDto.Title;
//                }
//                _unitOfWork.Repository<AttendanceType>().Update(result);
//                _unitOfWork.Commit();
//                var response = _mapper.Map<GetAttendanceTypeDto>(result);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }
//    }
//}
