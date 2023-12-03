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
    public class AboutCompanyService : IAboutCompanyService
    {
        private readonly IAboutCompanyRepository _aboutCompanyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AboutCompanyService(IAboutCompanyRepository aboutCompanyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _aboutCompanyRepository = aboutCompanyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult> AddAboutCompany(AddAboutCompanyDto aboutCompanyDto)
        {
            var about = _mapper.Map<AboutCompany>(aboutCompanyDto);
            about.IsActive = true;
            await _unitOfWork.Repository<AboutCompany>().AddAsync(about);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetAboutCompanyDto>(about);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> DeleteAboutCompany(int id)
        {
            var about = await _aboutCompanyRepository.GetAboutCompany(id);
            if (about != null)
            {
                about.IsActive = false;
                _unitOfWork.Repository<AboutCompany>().Update(about);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetAboutCompanyDto>(about);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveAboutCompanies()
        {
            var abouts = await _aboutCompanyRepository.GetActiveAboutCompanies();
            var response = _mapper.Map<List<GetAboutCompanyDto>>(abouts);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetAboutCompany(int id)
        {
            var about = await _aboutCompanyRepository.GetAboutCompany(id);
            var response = _mapper.Map<GetAboutCompanyDto>(about);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetLastAboutCompany()
        {
            var about = await _aboutCompanyRepository.GetLastAboutCompany();
            var response = _mapper.Map<GetAboutCompanyDto>(about);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetAllAboutCompanies()
        {
            var abouts = await _aboutCompanyRepository.GetAllAboutCompanies();
            var response = _mapper.Map<List<GetAboutCompanyDto>>(abouts);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateAboutCompany(AddAboutCompanyDto aboutCompanyDto, int id)
        {
            var about = await _aboutCompanyRepository.GetAboutCompany(id);
            if (about != null)
            {
                if (!aboutCompanyDto.MapAdress.IsNullOrEmpty())
                {
                    about.MapAdress = aboutCompanyDto.MapAdress;
                }

                if (!aboutCompanyDto.AzAdress.IsNullOrEmpty())
                {
                    about.AzAdress = aboutCompanyDto.AzAdress;
                }

                if (!aboutCompanyDto.EnAdress.IsNullOrEmpty())
                {
                    about.EnAdress = aboutCompanyDto.EnAdress;
                }

                if (!aboutCompanyDto.RuAdress.IsNullOrEmpty())
                {
                    about.RuAdress = aboutCompanyDto.RuAdress;
                }


                if (!aboutCompanyDto.Phone.IsNullOrEmpty())
                {
                    about.Phone = aboutCompanyDto.Phone;
                }
                if (!aboutCompanyDto.Email.IsNullOrEmpty())
                {
                    about.Email = aboutCompanyDto.Email;
                }
                if (!aboutCompanyDto.WebSite.IsNullOrEmpty())
                {
                    about.WebSite = aboutCompanyDto.WebSite;
                }
                if (!aboutCompanyDto.FacebookLink.IsNullOrEmpty())
                {
                    about.FacebookLink = aboutCompanyDto.FacebookLink;
                }

                if (!aboutCompanyDto.YoutubeLink.IsNullOrEmpty())
                {
                    about.YoutubeLink = aboutCompanyDto.YoutubeLink;
                }

                if (!aboutCompanyDto.TwitterLink.IsNullOrEmpty())
                {
                    about.TwitterLink = aboutCompanyDto.TwitterLink;
                }

                if (!aboutCompanyDto.InstagramLink.IsNullOrEmpty())
                {
                    about.InstagramLink = aboutCompanyDto.InstagramLink;
                }


                if (!aboutCompanyDto.LinkedinLink.IsNullOrEmpty())
                {
                    about.LinkedinLink = aboutCompanyDto.LinkedinLink;
                }

                if (!aboutCompanyDto.TelegramLink.IsNullOrEmpty())
                {
                    about.TelegramLink = aboutCompanyDto.TelegramLink;
                }


                _unitOfWork.Repository<AboutCompany>().Update(about);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetAboutCompanyDto>(about);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }
    }
}
