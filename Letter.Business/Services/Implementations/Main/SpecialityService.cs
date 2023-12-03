//using AutoMapper;
//using Letter.Business.Dtos.Get.Main;
//using Letter.Business.Dtos.Post.Main;
//using Letter.Business.Results;
//using Letter.Business.Services.Abstractions.Main;
//using Letter.DataAccess.Entities.Main;
//using Letter.DataAccess.Models;
//using Letter.DataAccess.Repositories.Abstractions.Main;
//using Letter.DataAccess.Repositories.Implementations.Main;
//using Letter.DataAccess.UnitOfWorks;
//using Microsoft.IdentityModel.Tokens;

//namespace Letter.Business.Services.Implementations.Main
//{
//    public class SpecialityService : ISpecialityService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;
//        private readonly ISpecialityRepository _specialityRepository;
//        private readonly IDirectionRepository _directionRepository;

//        public SpecialityService(IUnitOfWork unitOfWork, IMapper mapper, ISpecialityRepository specialityService, IDirectionRepository directionRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _specialityRepository = specialityService;
//            _directionRepository = directionRepository;
//        }
//        public async Task<ServiceResult> AddSpeciality(AddSpecialityDto speciality)
//        {
//            var request = _mapper.Map<Speciality>(speciality);
//            request.IsActive = true;
//            if (speciality.DirectionIds != null)
//                request.Directions = (await _unitOfWork.Repository<Direction>().GetAllAsync(x => speciality.DirectionIds.Contains(x.Id))).ToList();
//            await _unitOfWork.Repository<Speciality>().AddAsync(request);
//                _unitOfWork.Commit();
//                var response = _mapper.Map<GetSpecialityDto>(request);
//                return new ServiceResult(true, response);
//        }

//        public async Task<ServiceResult> DeleteSpecialityById(int specialityId)
//        {
//            var speciality = await _specialityRepository.GetSpeciality(specialityId);
//            if (speciality != null)
//            {
//                speciality.IsActive = false;
//                _unitOfWork.Repository<Speciality>().Update(speciality);
//                _unitOfWork.Commit();
//                var response = _mapper.Map<GetSpecialityDto>(speciality);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> UpdateSpeciality(AddSpecialityDto specialityDto, int specialityId)
//        {
//            var speciality = await _specialityRepository.GetSpeciality(specialityId);
//            if (speciality != null)
//            {
//                if (!specialityDto.AzName.IsNullOrEmpty())
//                {
//                    speciality.AzName = specialityDto.AzName;
//                }
//                if (!specialityDto.EnName.IsNullOrEmpty())
//                {
//                    speciality.EnName = specialityDto.EnName;
//                }
//                if (!specialityDto.RuName.IsNullOrEmpty())
//                {
//                    speciality.RuName = specialityDto.RuName;
//                }
//                if (!specialityDto.AzDescription.IsNullOrEmpty())
//                {
//                    speciality.AzDescription = specialityDto.AzDescription;
//                }
//                if (!specialityDto.EnDescription.IsNullOrEmpty())
//                {
//                    speciality.EnDescription = specialityDto.EnDescription;
//                }
//                if (!specialityDto.RuDescription.IsNullOrEmpty())
//                {
//                    speciality.RuDescription = specialityDto.RuDescription;
//                }
//                if (specialityDto.DirectionIds!=null)
//                {
//                    speciality.Directions = (await _unitOfWork.Repository<Direction>().GetAllAsync(x => specialityDto.DirectionIds.Contains(x.Id))).ToList();
//                }
//                _unitOfWork.Repository<Speciality>().Update(speciality);
//                _unitOfWork.Commit();
//                var response = _mapper.Map<GetSpecialityDto>(speciality);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> GetSpecialities()
//        {
//            var specialities = await _specialityRepository.GetAllSpecialities();
//            if (specialities != null)
//            {
//                var response = _mapper.Map<List<GetSpecialityDto>>(specialities);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> GetSpeciality(int id)
//        {
//            var speciality = await _specialityRepository.GetSpeciality(id);
//            if (speciality != null)
//            {
//                var response = _mapper.Map<GetSpecialityWithUniveristyDto>(speciality);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> GetActiveSpecialities()
//        {
//            var specialities = await _specialityRepository.GetActiveSpecialities();
//            if (specialities != null)
//            {
//                var response = _mapper.Map<List<GetSpecialityDto>>(specialities);
//                return new ServiceResult(true, response);
//            }
//            return new ServiceResult(false);
//        }

//        public async Task<ServiceResult> SearchSpeciality(int currentPage, int pageSize, SpecialitySearchModelDto documentSearchModel)
//        {
//            if (pageSize > 100)
//                pageSize = 100;

//            var speciality = _mapper.Map<SpecialitySearchModel>(documentSearchModel);
//            var query = _specialityRepository.SearcProduct(speciality);

//            var page = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

//            SearchResult<IEnumerable<GetSpecialityDto>> response = new SearchResult<IEnumerable<GetSpecialityDto>>()
//            {
//                Value = _mapper.Map<IEnumerable<GetSpecialityDto>>(page.Select(p => p)),
//                DataCount = query.Count(),
//                CurrentPage = currentPage,
//                PageSize = pageSize
//            };

//            return new ServiceResult(true, response);
//        }

//    }
//}
