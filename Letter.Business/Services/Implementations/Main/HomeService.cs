using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Models;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Letter.DataAccess.UnitOfWorks;
using Letter.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Letter.Business.Services.Implementations.Main;

public class HomeService : IHomeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHomeRepository _homeRepository;
    private readonly IHomeTypeRepository _typeRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IStatusRepository _statusRepository;
    private readonly ISession _session;

    public HomeService(IUnitOfWork unitOfWork,
        IMapper mapper,
        IHomeRepository homeRepository,
        IHomeTypeRepository typeRepository,
        ICityRepository cityRepository,
        IHttpContextAccessor session
,
        IStatusRepository statusRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _homeRepository = homeRepository;
        _cityRepository = cityRepository;
        _typeRepository = typeRepository;
        _session = session.HttpContext.Session;
        _statusRepository = statusRepository;
    }

    public async Task<ServiceResult> AddHome(AddHomeDto home)
    {
        var request = _mapper.Map<Home>(home);
        var status = await _statusRepository.GetFirstStatus();
        request.IsActive = true;
        request.StatusId = status.Id;

        await _unitOfWork.Repository<Home>().AddAsync(request);
        _unitOfWork.Commit();

        var response = _mapper.Map<GetHomeDto>(request);
        return new ServiceResult(true, response.Id);
    }

    public async Task<ServiceResult> DeleteHomeById(int id)
    {
        var home = await _homeRepository.GetHome(id);
        if (home != null)
        {
            home.IsActive = false;
            _unitOfWork.Repository<Home>().Update(home);
            _unitOfWork.Commit();
            return new ServiceResult(true, home.Id);
        }
        return new ServiceResult(false);
    }

    public async Task<ServiceResult> GetAllHomes()
    {
        var homes = await _homeRepository.GetAllHomes();
        if (!homes.Any())
            return new ServiceResult(false);

        var response = _mapper.Map<List<GetHomeDto>>(homes);
        return new ServiceResult(true, response);
    }






    public async Task<ServiceResult> GetActiveHomes()
    {
        var homes = await _homeRepository.GetActiveHomes();

        var response = _mapper.Map<List<GetHomeDto>>(homes);
        return new ServiceResult(true, response);
    }

    public async Task<ServiceResult> GetHomesName()
    {
        var homes = await _homeRepository.GetActiveHomesName();
        if (!homes.Any())
            return new ServiceResult(false);
        var response = _mapper.Map<List<GetHomeIdNameDto>>(homes);
        return new ServiceResult(true, response);
    }

    public async Task<ServiceResult> GetHome(int id)
    {
        try
        {
            var result = await _homeRepository.GetHome(id);
            if (result == null)
                return new ServiceResult(false, "data not found");

            var response = _mapper.Map<GetHomeDto>(result);
            return new ServiceResult(true, response);
        }
        catch (Exception ex)
        {
            return new ServiceResult(false, ex.Message);
        }
    }

    public async Task<ServiceResult> GetHomesWithCityId(int cityId)
    {
        var univer = await _homeRepository.GetHomesByCity(cityId);
        if (univer != null)
        {
            var response = _mapper.Map<List<GetHomeDto>>(univer);
            return new ServiceResult(true, response);
        }
        return new ServiceResult(false);
    }

    //public async Task<ServiceResult> SearchUniversity(int currentPage, int pageSize, UniversitySearchModelDto documentSearchModel)
    //{
    //    if (pageSize > 100)
    //        pageSize = 100;

    //    var home = _mapper.Map<UniversitySearchModel>(documentSearchModel);
    //    var query = _homeRepository.SearcProduct(home);

    //    var page = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

    //    SearchResult<IEnumerable<GetHomeDto>> response = new SearchResult<IEnumerable<GetHomeDto>>()
    //    {
    //        Value = _mapper.Map<IEnumerable<GetHomeDto>>(page.Select(p => p)),
    //        DataCount = query.Count(),
    //        CurrentPage = currentPage,
    //        PageSize = pageSize
    //    };

    //    return new ServiceResult(true, response);
    //}

    public async Task<ServiceResult> UpdateHome(UpdateHomeDto homeDto, int id)
    {
        var home = await _homeRepository.GetHome(id);
        if (home != null)
        {
            if (!homeDto.AzName.IsNullOrEmpty())
            {
                home.AzName = homeDto.AzName;
            }
            if (!homeDto.EnName.IsNullOrEmpty())
            {
                home.EnName = homeDto.EnName;
            }
            if (!homeDto.RuName.IsNullOrEmpty())
            {
                home.RuName = homeDto.RuName;
            }

            if (!homeDto.AzDescription.IsNullOrEmpty())
            {
                home.AzDescription = homeDto.AzDescription;
            }
            if (!homeDto.EnDescription.IsNullOrEmpty())
            {
                home.EnDescription = homeDto.EnDescription;
            }
            if (!homeDto.RuDescription.IsNullOrEmpty())
            {
                home.RuDescription = homeDto.RuDescription;
            }

            if (!homeDto.MapAdrress.IsNullOrEmpty())
            {
                home.MapAdrress = homeDto.MapAdrress;
            }
            if (!homeDto.AzAddress.IsNullOrEmpty())
            {
                home.AzAddress = homeDto.AzAddress;
            }
            if (!homeDto.EnAddress.IsNullOrEmpty())
            {
                home.EnAddress = homeDto.EnAddress;
            }
            if (!homeDto.RuAddress.IsNullOrEmpty())
            {
                home.RuAddress = homeDto.RuAddress;
            }

            if (homeDto.CityId != null)
            {
                home.CityId = homeDto.CityId.Value;
            }
            if (homeDto.TypeId != null)
            {
                home.TypeId = homeDto.TypeId.Value;
            }
            if (homeDto.StatusId != null)
            {
                home.StatusId = homeDto.StatusId.Value;
            }





            _unitOfWork.Repository<Home>().Update(home);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetHomeDto>(home);
            return new ServiceResult(true, response.Id);
        }
        return new ServiceResult(false);
    }

    public async Task<ServiceResult> SearchHome(int currentPage, int pageSize, HomeSearchModelDto documentSearchModel)
    {
        if (pageSize > 100)
            pageSize = 100;

        var home = _mapper.Map<HomeSearchModel>(documentSearchModel);
        var query = _homeRepository.SearcHome(home);

        var page = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        SearchResult<IEnumerable<GetHomeDto>> response = new SearchResult<IEnumerable<GetHomeDto>>()
        {
            Value = _mapper.Map<IEnumerable<GetHomeDto>>(page.Select(p => p)),
            DataCount = query.Count(),
            CurrentPage = currentPage,
            PageSize = pageSize
        };

        return new ServiceResult(true, response);
    }

    public async Task<ServiceResult> GetHomesByUserId()
    {
        var userData = _session.GetObject<UserSessionDto>("userdetail");
        if (userData == null)
        {
            return new ServiceResult(false);
        }
        var homes = _homeRepository.GetHomeByUserId(userData.Id);
        if (homes != null)
        {
            var response = _mapper.Map<List<GetHomeDto>>(homes);
            return new ServiceResult(true, response);
        }
        return new ServiceResult(false);
    }

    public async Task<ServiceResult> GetHomesTypeName(string typeName)
    {
        var univer = await _homeRepository.GetHomesByTypeName(typeName);
        if (univer != null)
        {
            var response = _mapper.Map<List<GetHomeDto>>(univer);
            return new ServiceResult(true, response);
        }
        return new ServiceResult(false);
    }

    public async Task<ServiceResult> GetHomesStatusId(int statusId)
    {
        try
        {
            var result = await _homeRepository.GetHomesByStatusId(statusId);
            if (result == null)
                return new ServiceResult(false, "data not found");

            var response = _mapper.Map<List<GetHomeDto>>(result);
            return new ServiceResult(true, response);
        }
        catch (Exception ex)
        {
            return new ServiceResult(false, ex.Message);
        }
    }
    /*




public string AzAbout { get; set; }
public string EnAbout { get; set; }
public string RuAbout { get; set; }

public string AzStudentLife { get; set; }
public string EnStudentLife { get; set; }
public string RuStudentLife { get; set; }

public string AzServices { get; set; }
public string EnServices { get; set; }
public string RuServices { get; set; }

public string AzBachelor { get; set; }
public string EnBachelor { get; set; }
public string RuBachelor { get; set; }

public string AzMaster { get; set; }
public string EnMaster { get; set; }
public string RuMaster { get; set; }

public int? Rank { get; set; }
public DateTime StartDate { get; set; }
public DateTime ApplyDate { get; set; }

//public List<int>? DurationIds { get; set; }

//public List<int>? AttendanceIds { get; set; }

public List<int>? SpecialityIds { get; set; }

public List<int>? ProgramIds { get; set; }

public List<int> DirectionIds { get; set; }

*/

    //public async Task<ServiceResult> AddSpeciality(AddUniversitySpecialityDto homeDto, int id)
    //{
    //    var home = await _homeRepository.GetUniverity(id);
    //    if (home != null)
    //    {
    //        var specialities = new List<Speciality>();
    //        var speciality = new List<Speciality>();

    //        foreach (var item in home.Directions)
    //        {
    //            specialities.AddRange(await _specialityRepository.GetSpecialitiesViaDirection(item.Id));
    //        }

    //        foreach (var item in homeDto.SpecialityIds)
    //        {
    //            if (specialities.FirstOrDefault(x => x.Id == item) != null)
    //            {
    //                speciality.Add(specialities.FirstOrDefault(x => x.Id == item));
    //            }
    //        }
    //        home.Specialities = speciality;
    //        _unitOfWork.Repository<Home>().Update(home);
    //        _unitOfWork.Commit();
    //        var response = _mapper.Map<GetHomeDto>(home);
    //        return new ServiceResult(true, response.Id);
    //    }
    //    return new ServiceResult(false);
    //}

    //public async  Task<ServiceResult> GetRandomUniverisities()
    //{
    //    var request = await _homeRepository.GetRandomActiveUniversities();
    //    var response = _mapper.Map<IEnumerable<GetUniversityIdNameDto>>(request);
    //    return new ServiceResult(true, response);
    //}
}
