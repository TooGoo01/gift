using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Letter.DataAccess.Repositories.Implementations.Main;
using Letter.DataAccess.UnitOfWorks;
using Microsoft.IdentityModel.Tokens;

namespace Letter.Business.Services.Implementations.Main
{
    public class IconService : IIconService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIconRepository _iconRepository;

        public IconService(IMapper mapper, IUnitOfWork unitOfWork, IIconRepository iconRepository)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _iconRepository = iconRepository;
        }

        public async Task<ServiceResult> AddIcon(AddIconDto icon)
        {
            var request = _mapper.Map<Icon>(icon);
            request.IsActive = true;
            await _unitOfWork.Repository<Icon>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetIconDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeleteIconById(int iconId)
        {
            var icon = await _iconRepository.GetIcon(iconId);
            if (icon != null)
            {
                icon.IsActive = false;
                _unitOfWork.Repository<Icon>().Update(icon);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetIconDto>(icon);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveIcons()
        {
            var request = await _iconRepository.GetActiveIcons();
            var response = _mapper.Map<IEnumerable<GetIconDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetIcon(int iconId)
        {
            var request = await _iconRepository.GetIcon(iconId);

            var response = _mapper.Map<GetIconDto>(request);
            return new ServiceResult(true, response);
        }

        public Task<ServiceResult> GetIconByCityId(int cityId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> GetIcons()
        {
            var request = await _iconRepository.GetActiveIcons();
            var response = _mapper.Map<IEnumerable<GetIconDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdateIcon(AddIconDto iconDto, int id)
        {
            var icon = await _iconRepository.GetIcon(id);
            if (icon != null)
            {
                if (!iconDto.IconName.IsNullOrEmpty())
                {
                    icon.IconName = iconDto.IconName;
                }
               

                _unitOfWork.Repository<Icon>().Update(icon);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetIconDto>(icon);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }
    }
}
