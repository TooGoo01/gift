using AutoMapper;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class PersonalAboutService : IPersonalAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonalAboutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult> AddPersonalAbouts(AddPersonalAbout about)
        {
            if (about.Email == null || about.Phone1 == null || about.City == null || about.District == null || about.Street == null)
            {
                return new ServiceResult(false, "required");
            }
            var data = _mapper.Map<MainAbout>(about);
            await _unitOfWork.Repository<MainAbout>().AddAsync(data);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> DeletePersonalAboutById(int aboutId)
        {
            try
            {
                var meet = await _unitOfWork.Repository<MainAbout>().GetAsync(x => x.Id == aboutId);
                if (meet == null)
                    return new ServiceResult(false, "Belə məhsul mövcud deyil!");

                _unitOfWork.Repository<MainAbout>().Delete(x => x.Id == aboutId);
                _unitOfWork.Commit();

                return new ServiceResult(true, "About silindi");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> GetPersonalAbouts()
        {
            var about = await _unitOfWork.Repository<MainAbout>().GetAllAsync();

            if (about == null)
                return new ServiceResult(false);

            return new ServiceResult(true, about);
        }
    }
}
