using Letter.Business.Dtos.Post.Main;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Main
{
    public interface IContactService
    {
        #region Post
        Task<ServiceResult> AddContact(AddContactDto contact);
        ServiceResult DeleteContactById(int contactId);

        #endregion

        #region Get
        Task<ServiceResult> GetContacts();
        #endregion
    }
}
