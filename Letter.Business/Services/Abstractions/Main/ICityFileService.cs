using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface ICityFileService
    {
        Task<ServiceResult> AddRangeAsync(AddCityDto country, int contId);
        Task<ServiceResult> UpdateRangeAsync(AddCityDto countryDto, int contId);
    }
}
