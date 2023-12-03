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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly IIconRepository _iconRepository;
        public CityService(IUnitOfWork unitOfWork, IMapper mapper, ICityRepository cityRepository, IIconRepository iconRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cityRepository = cityRepository;
            _iconRepository = iconRepository;
        }
        #region POST
        //admin
        public async Task<ServiceResult> AddCity(AddCityDto city)
        {
            var request = _mapper.Map<City>(city);
            request.IsActive = true;
            if (city.iconIds != null)
                request.Icons = (await _unitOfWork.Repository<Icon>().GetAllAsync(x => city.iconIds.Contains(x.Id))).ToList();
            await _unitOfWork.Repository<City>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetCityDto>(request);
            return new ServiceResult(true, response.Id);
        }
        //admin
        public async Task<ServiceResult> ActivateCity(int cityId)
        {
            var city = await _cityRepository.GetCity(cityId);

            if (city == null)
                return new ServiceResult(false, "Ölkə mövcud deyil.");

            if (city.IsActive)
                return new ServiceResult(false, "Ölkə artıq aktivdir.");

            city.IsActive = true;
            _unitOfWork.Commit();
            return new ServiceResult(true, city);
        }
        #endregion

        #region Get
        //admin
        public async Task<ServiceResult> GetAllCities()
        {
            var request = await _cityRepository.GetAllCities();
            var response = _mapper.Map<List<GetCityDto>>(request);
            return new ServiceResult(true, response);
        }

        //public async Task<ServiceResult> GetAllCountriesIdName()
        //{
        //    var request = await _cityRepository.GetCitiesIdName();
        //    var response = _mapper.Map<List<GetCityIdNameDto>>(request);
        //    return new ServiceResult(true, response);
        //}

        //user
        public async Task<ServiceResult> GetActiveCities()
        {
            var request = await _cityRepository.GetActiveCities();
            var response = _mapper.Map<IEnumerable<GetCityDto>>(request);
            return new ServiceResult(true, response);
        }
        public async Task<ServiceResult> GetDeActiveCities()
        {
            var request = await _cityRepository.GetDeActiveCities();
            var response = _mapper.Map<IEnumerable<GetCityDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetCity(int cityId)
        {
            var request = await _cityRepository.GetCity(cityId);

            var response = _mapper.Map<GetCityDto>(request);
            return new ServiceResult(true, response);
        }

        //public async Task<ServiceResult> GetRandomActiveCountries()
        //{
        //    var request = await _cityRepository.GetRandomActiveCities();
        //    var response = _mapper.Map<IEnumerable<GetCityDto>>(request);
        //    return new ServiceResult(true, response);
        //}
        #endregion

        #region Put
        public async Task<ServiceResult> UpdateCity(AddCityDto cityDto, int id)
        {
            var city = await _cityRepository.GetCity(id);
            if (city != null)
            {
                if (!cityDto.AzName.IsNullOrEmpty())
                {
                    city.AzName = cityDto.AzName;
                }
                if (!cityDto.EnName.IsNullOrEmpty())
                {
                    city.EnName = cityDto.EnName;
                }
                if (!cityDto.RuName.IsNullOrEmpty())
                {
                    city.RuName = cityDto.RuName;

                }
                if (!cityDto.AzDescription.IsNullOrEmpty())
                {
                    city.AzDescription = cityDto.AzDescription;
                }
                if (!cityDto.EnDescription.IsNullOrEmpty())
                {
                    city.EnDescription = cityDto.EnDescription;

                }
                if (!cityDto.RuDescription.IsNullOrEmpty())
                {
                    city.RuDescription = cityDto.RuDescription;
                }

                if (!cityDto.Population.HasValue)
                {
                    city.Population = cityDto.Population.Value;
                }
                if (cityDto.iconIds != null)
                {
                    city.Icons = (await _unitOfWork.Repository<Icon>().GetAllAsync(x =>cityDto.iconIds.Contains(x.Id))).ToList();
                }
                _unitOfWork.Repository<City>().Update(city);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetCityDto>(city);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }
        #endregion
        #region Delete
        public async Task<ServiceResult> DeleteCity(int id)
        {
            var city = await _cityRepository.GetCity(id);
            if (city != null)
            {
                city.IsActive = false;
                _unitOfWork.Repository<City>().Update(city);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetCityDto>(city);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }

    

        public Task<ServiceResult> GetAllCitiesIdName()
        {
            throw new NotImplementedException();
        }

      

        public Task<ServiceResult> GetRandomActiveCities()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> SearchCity(int currentPage, int pageSize)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
