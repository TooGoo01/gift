using AutoMapper;
using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.DataAccess.Entities.Main;
using Letter.DataAccess.UnitOfWorks;

namespace Letter.Business.Services.Implementations.Main
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResult> AddContact(AddContactDto contact)
        {
            var request = _mapper.Map<Contact>(contact);

            await _unitOfWork.Repository<Contact>().AddAsync(request);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public ServiceResult DeleteContactById(int contactId)
        {
            var meet = _unitOfWork.Repository<Contact>().CheckExist(x => x.Id == contactId);

            if (meet == false)
                return new ServiceResult(false, "Contact not found");

            _unitOfWork.Repository<Contact>().Delete(x => x.Id == contactId);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> GetContacts()
        {
            var meets = await _unitOfWork.Repository<Contact>().GetAllAsync();

            if (meets == null)
                return new ServiceResult(false);

            return new ServiceResult(true, meets);
        }
    }

}
