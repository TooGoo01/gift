using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IContactPageRepository : IGenericRepository<ContactPage>
    {
        Task<ContactPage> GetContactPageById(int id);
        Task<ContactPage> GetLastContactPage();
        Task<IEnumerable<ContactPage>> GetAllContactPages();

    }
}
