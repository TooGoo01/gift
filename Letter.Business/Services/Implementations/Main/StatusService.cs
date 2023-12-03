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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Services.Implementations.Main
{
    public class StatusService : IStausService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStatusRepository _statusRepository;
        public StatusService(IUnitOfWork unitOfWork, IMapper mapper, IStatusRepository statusRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _statusRepository = statusRepository;
        }

        public async Task<ServiceResult> AddStatus(AddStatusDto status)
        {
            var request = _mapper.Map<Status>(status);
            request.IsActive = true;
            await _unitOfWork.Repository<Status>().AddAsync(request);
            _unitOfWork.Commit();
            var response = _mapper.Map<GetStatusDto>(request);
            return new ServiceResult(true, response);
        }

        public async Task<ServiceResult> DeleteStatus(int statusId)
        {
            var status = await _statusRepository.GetStatus(statusId);
            if (status != null)
            {
                status.IsActive = false;
                _unitOfWork.Repository<Status>().Update(status);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetStatusDto>(status);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);

        }

        public async Task<ServiceResult> GetActiveStatuses()
        {
            var status = await _statusRepository.GetActiveStatus();
            if (status != null)
            {
                var response = _mapper.Map<List<GetStatusDto>>(status);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetStatuses()
        {
            var status = await _statusRepository.GetAllStatus();
            if (status != null)
            {
                var response = _mapper.Map<List<GetStatusDto>>(status);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetStatusId(int statusId)
        {
            var status = await _statusRepository.GetStatus(statusId);
            if (status != null)
            {
                var response = _mapper.Map<GetStatusDto>(status);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateStatus(AddStatusDto status, int id)
        {
            var status1 = await _statusRepository.GetStatus(id);
            if (status1 != null)
            {
                if (!status.AzName.IsNullOrEmpty())
                {
                    status1.AzName = status.AzName;
                }
                if (!status.EnName.IsNullOrEmpty())
                {
                    status1.EnName = status.EnName;
                }
                if (!status.RuName.IsNullOrEmpty())
                {
                    status1.RuName = status.RuName;
                }

                if (!status.AzDescription.IsNullOrEmpty())
                {
                    status1.AzDescription = status.AzDescription;
                }
                if (!status.EnDescription.IsNullOrEmpty())
                {
                    status1.EnDescription = status.EnDescription;
                }
                if (!status.RuDescription.IsNullOrEmpty())
                {
                    status1.RuDescription = status.RuDescription;
                }

                





                _unitOfWork.Repository<Status>().Update(status1);
                _unitOfWork.Commit();
                var response = _mapper.Map<GetStatusDto>(status1);
                return new ServiceResult(true, response.Id);
            }
            return new ServiceResult(false);
        }

       
    }
}
