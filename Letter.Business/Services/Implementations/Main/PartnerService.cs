using AutoMapper;
using Letter.Business.Dtos.Get.Main;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.Repositories.Abstractions.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class PartnerService : IPartnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IUnitOfWork unitOfWork, IMapper mapper, IPartnerRepository partnerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }
        public async Task<ServiceResult> AddPartner(AddPartnerDto partner)
        {
            var request = _mapper.Map<Partner>(partner);
            request.IsActive = true;
            await _unitOfWork.Repository<Partner>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetPartnerDto>(request);
            return new ServiceResult(true, response.Id);
        }

        public async Task<ServiceResult> DeletePartner(int id)
        {
            var partner = await _partnerRepository.GetPartner(id);
            partner.IsActive = false;
            _unitOfWork.Repository<Partner>().Update(partner);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> GetActivePartners()
        {
            var request = await _partnerRepository.GetActivePartners();
            var response = _mapper.Map<IEnumerable<GetPartnerDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPartner(int id)
        {
            var request = await _partnerRepository.GetPartner(id);

            var response = _mapper.Map<GetPartnerDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> GetPartners()
        {
            var request = await _partnerRepository.GetAllPartners();

            var response = _mapper.Map<IEnumerable<GetPartnerDto>>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> UpdatePartner(AddPartnerDto partnerDto, int id)
        {
            var partner = await _partnerRepository.GetPartner(id);
            if (partner != null)
            {
                if (!string.IsNullOrEmpty(partnerDto.AzName))
                {
                    partner.AzName = partnerDto.AzName;
                }
                if (!string.IsNullOrEmpty(partnerDto.EnName))
                {
                    partner.EnName = partnerDto.EnName;
                }
                if (!string.IsNullOrEmpty(partnerDto.RuName))
                {
                    partner.RuName = partnerDto.RuName;
                }

                if (!string.IsNullOrEmpty(partnerDto.AzDescription))
                {
                    partner.AzDescription = partnerDto.AzDescription;
                }
                if (!string.IsNullOrEmpty(partnerDto.EnDescription))
                {
                    partner.EnDescription = partnerDto.EnDescription;

                }
                if (!string.IsNullOrEmpty(partnerDto.RuDescription))
                {
                    partner.RuDescription = partnerDto.RuDescription;
                }

                if (!string.IsNullOrEmpty(partnerDto.Link))
                {
                    partner.Link = partnerDto.Link;
                }

                _unitOfWork.Repository<Partner>().Update(partner);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetPartnerDto>(partner);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }
    }
}
