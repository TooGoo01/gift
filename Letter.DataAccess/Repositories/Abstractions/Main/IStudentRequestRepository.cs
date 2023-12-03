using Letter.DataAccess.Entities.Main;

namespace Letter.DataAccess.Repositories.Abstractions.Main
{
    public interface IStudentRequestRepository : IGenericRepository<StudentRequest>
    {
        Task<ICollection<StudentRequest>> GetAllStudentRequests();
        Task<ICollection<StudentRequest>> GetActiveStudentRequests();
        Task<StudentRequest> GetStudentRequest(int id);
        Task<ICollection<StudentRequest>> GetStudentRequestsByCountry(string country);
        Task<StudentRequest> GetLastStudentRequest();
        Task<ICollection<StudentRequest>> GetSeenStudentRequests();
        Task<ICollection<StudentRequest>> GetNonSeenStudentRequests();
    }
}
