using Letter.Business.Dtos.Post.Users;
using Letter.Business.Results;

namespace Letter.Business.Services.Abstractions.Users
{
    public interface IUserService
    {
        Task<ServiceResult> GetUser(string userId);
        Task<ServiceResult> DeleteUser(string userId);
        Task<ServiceResult> AddUser(RegisterUserDto registerUser);
        Task<ServiceResult> Register(RegisterUserDto registerUser);
        Task<ServiceResult> LogIn(LoginUserDto loginUser);
        Task<ServiceResult> LogOut();
        Task<ServiceResult> AddClaim(AddClaimDto claim);
        Task<ServiceResult> GetUsers();
        Task<ServiceResult> GetLoggedUser();
        Task PasswordResetAsync(string email);
        Task<bool> VerifyResetTokenAsync(string resetToke, string UserName);
        Task<bool> UpdatePassword(string userName, string resetToken, string newPassword);
        Task<bool> EmailConfirmAsync(string email);
        Task<bool> VerifyConfirmAsync(string userName, string confirmToken);
        Task<ServiceResult> Verify(string phone, string randomString);
    }
}
