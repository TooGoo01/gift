using AutoMapper;
using Letter.Business.Dtos.Get.Users;
using Letter.Business.Dtos.Post.Users;
using Letter.Business.Helpers;
using Letter.Business.Results;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Users;
using Letter.DataAccess.Context;
using Letter.DataAccess.Entities.Users;
using Letter.DataAccess.Models;
using Letter.DataAccess.UnitOfWorks;
using Letter.Infrastructure.Extensions;
using Letter.Infrastructure.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;
using System.Security.Claims;

namespace Letter.Business.Services.Implementations.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly LetterDbContext _dbContext;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISession _session;
        private readonly IMailService _mailService;
        public UserService(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IMapper mapper,
                            ITokenHelper tokenHelper,
                            IHttpContextAccessor httpContextAccessor,
                            IUnitOfWork unitOfWork, LetterDbContext dbContext,
                            IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
            _session = httpContextAccessor.HttpContext.Session;
            _dbContext = dbContext;
            _mailService = mailService;
        }

        public async Task<ServiceResult> AddClaim(AddClaimDto addClaim)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(addClaim.UserId);
               
                await _userManager.UpdateAsync(user);
                var claim = new Claim(addClaim.ClaimType, addClaim.ClaimName);

                if (user == null)
                    return new ServiceResult(false, "user not found");

                var result = await _userManager.AddClaimAsync(user, claim);

                if (result.Succeeded)
                    return new ServiceResult(true, "aded claim successfull");

                return new ServiceResult(false, String.Join(';', result.Errors.Select(x => x.Code)));
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }


        public async Task<ServiceResult> AddUser(RegisterUserDto registerUser)
        {
            var requestData = _mapper.Map<ApplicationUser>(registerUser);
            IdentityResult result = await _userManager.CreateAsync(requestData, "1234dd");

            if (result.Succeeded)
                return new ServiceResult(true, "registration completed");

            return new ServiceResult(false, String.Join(';', result.Errors.Select(x => x.Code)));
        }


        public async Task<ServiceResult> GetLoggedUser()
        {
            try
            {
                var userData = _session.GetObject<UserSessionDto>("userdetail");
                if (userData == null)
                    return new ServiceResult(false, "data not found");

                return new ServiceResult(true, userData);
            }
            catch (Exception)
            {
                return new ServiceResult(false, "data not found");
            }
        }

        public async Task<ServiceResult> GetUser(string userId)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(userId);

                if (result != null)
                {
                    var response = _mapper.Map<ApplicationUserDto>(result);
                    return new ServiceResult(true, response, "user successfully found");
                }

                return new ServiceResult(false, "user not found");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> GetUsers()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                if (users != null)
                {
                    var response = _mapper.Map<IEnumerable<ApplicationUserDto>>(users);
                    return new ServiceResult(true, response);
                }

                return new ServiceResult(false, "user not found");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> LogIn(LoginUserDto loginUser)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginUser.UserName);

                if (user == null)
                    return new ServiceResult(false, "user not found");
                if (user.IsVerify == false)
                    return new ServiceResult(false, "user not verified");

                var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, true, false);
                var claims = await _userManager.GetClaimsAsync(user);


                //var token = _tokenHelper.CreateToken(_mapper.Map<ApplicationUser>(user), claims);

                if (!result.Succeeded)
                {

                    return new ServiceResult(false, "loginfiled");
                }

                var detail = new UserSessionDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.Name,
                    LastName = user.Surname,
                    Email = user.Email,
                };
                _session.SetObject("userdetail", detail);
                return new ServiceResult(true,"login success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return new ServiceResult(true, "successfully logout");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task PasswordResetAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                resetToken = resetToken.UrlEncode();
                await _mailService.SendPasswordResetMail(email, user.UserName, resetToken);
            }
        }
        public async Task<bool> EmailConfirmAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string confirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                confirmToken = confirmToken.UrlEncode();
                await _mailService.SendEmailConfirmMail(email, user.UserName, confirmToken);
                return true;
            }
            return false;
        }

        public async Task<ServiceResult> Register(RegisterUserDto registerUser)
        {
            try
            {
                
                var name = await _userManager.FindByNameAsync(registerUser.Phone);
                if (name != null)
                    return new ServiceResult(false, "username alreadyused");
                ApplicationUser requestData = new ApplicationUser
                {
                    Name = registerUser.Name,
                    Surname = registerUser.Surname,
                    UserName=registerUser.Phone,
                    IsVerify = false,

                };
                IdentityResult result = await _userManager.CreateAsync(requestData, registerUser.Password);

                if (result.Succeeded)
                {
                    string random = Helper.GetRandomString();
                    var message = $"Sizin birdefelik tesdiq shifreniz " + random;
                    requestData.Random=random;
                    await _userManager.UpdateAsync(requestData);
                    await Helper.SendSmsAsync(registerUser.Phone, message);
                    return new ServiceResult(true, "registration completed");
                }
                return new ServiceResult(false, "unknownerror");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<bool> UpdatePassword(string userName, string resetToken, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    return true;

                }
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> VerifyConfirmAsync(string userName, string confirmToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                confirmToken = confirmToken.UrlDecode();
                var result = await _userManager.ConfirmEmailAsync(user, confirmToken);
                if (result.Succeeded)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }

        public async Task<ServiceResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> Verify(string phone, string inputRandom)
        {
            var name = await _userManager.FindByNameAsync(phone);
            if (name == null)
                return new ServiceResult(false,"user not found");
            if(inputRandom == null)
            {
                return new ServiceResult(false, "rantom not found");
            }
            else if (inputRandom.ToLower() != name.Random.ToLower())
            {
                return new ServiceResult(false, "random not match");
            }
            name.IsVerify = true;
            await _userManager.UpdateAsync(name);
            return new ServiceResult(true, "phone verified");
        }
    }
}
