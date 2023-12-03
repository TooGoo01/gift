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
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IAboutRepository aboutRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aboutRepository = aboutRepository;
        }

        public async Task<ServiceResult> AddAbouts(AddAboutDto about)
        {
            var request = _mapper.Map<About>(about);
            request.IsActive = true;
            await _unitOfWork.Repository<About>().AddAsync(request);
            _unitOfWork.Commit();

            var response = _mapper.Map<GetAboutDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeleteAboutById(int aboutId)
        {
            var about = await _aboutRepository.GetAbout(aboutId);
            if (about != null)
            {
                about.IsActive = false;
                _unitOfWork.Repository<About>().Update(about);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetAbout(int aboutId)
        {
            try
            {
                var result = await _aboutRepository.GetAbout(aboutId);
                if (result == null)
                    return new ServiceResult(false, "data not found");

                var response = _mapper.Map<GetAboutDto>(result);
                return new ServiceResult(true, response);
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> GetAbouts()
        {

            var about = await _aboutRepository.GetAbouts();
            if (about != null)
            {
                var response = _mapper.Map<List<GetAboutDto>>(about);
                return new ServiceResult(true, response);
            }

            return new ServiceResult(false);

        }

        public async Task<ServiceResult> GetActiveAbouts()
        {
            var about = await _aboutRepository.GetActiveAbouts();
            if (about != null)
            {
                var response = _mapper.Map<List<GetAboutDto>>(about);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateAbout(AddAboutDto aboutDto, int id)
        {
            var about = await _aboutRepository.GetAbout(id);
            if (about != null)
            {
                //var request = _mapper.Map<About>(aboutDto);
                if (!aboutDto.AzHeader.IsNullOrEmpty())
                {
                    about.AzHeader = aboutDto.AzHeader;
                }
                if (!aboutDto.EnHeader.IsNullOrEmpty())
                {
                    about.EnHeader = aboutDto.EnHeader;
                }
                if (!aboutDto.RuHeader.IsNullOrEmpty())
                {
                    about.RuHeader = aboutDto.RuHeader;
                }

                if (!aboutDto.AzDescription.IsNullOrEmpty())
                {
                    about.AzDescription = aboutDto.AzDescription;
                }
                if (!aboutDto.EnDescription.IsNullOrEmpty())
                {
                    about.EnDescription = aboutDto.EnDescription;
                }
                if (!aboutDto.RuDescription.IsNullOrEmpty())
                {
                    about.RuDescription = aboutDto.RuDescription;
                }

                if (!aboutDto.YoutubeLink.IsNullOrEmpty())
                {
                    about.YoutubeLink = aboutDto.YoutubeLink;
                }
                if (!aboutDto.FacebookLink.IsNullOrEmpty())
                {
                    about.FacebookLink = aboutDto.FacebookLink;
                }
                if (!aboutDto.InstagramLink.IsNullOrEmpty())
                {
                    about.InstagramLink = aboutDto.InstagramLink;
                }
                if (!aboutDto.TwitterLink.IsNullOrEmpty())
                {
                    about.TwitterLink = aboutDto.TwitterLink;
                }
                _unitOfWork.Repository<About>().Update(about);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetAboutDto>(about);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }
    }
}
