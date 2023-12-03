using Letter.DataAccess.Entities.Main.Front;

namespace Letter.DataAccess.Repositories.Abstractions.Main.Front
{
    public interface IStudentWordsFrontRepository : IGenericRepository<StudentWordsFront>
    {
        Task<IEnumerable<StudentWordsFront>> GetAllStudentWordsFront();
        Task<StudentWordsFront> GetLastStudentWordsFront();
        Task<StudentWordsFront> GetStudentWordsFtont(int id);
    }
}
