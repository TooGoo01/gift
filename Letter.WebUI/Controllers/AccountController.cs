using Letter.Business.Dtos.Post.Users;
using Letter.Business.Services.Abstractions.Main;
using Letter.Business.Services.Abstractions.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Numerics;

namespace EstateBe.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHomeService _homeService;
        private readonly IStringLocalizer<AccountController> _localizer;



        public AccountController(IUserService userService, IStringLocalizer<AccountController> localizer, IHomeService homeService)
        {
            _userService = userService;
            _localizer = localizer;
            _homeService = homeService;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Error");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> Verify(string phone)
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Error");
            }
            else
            {

                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(string phone, string inputRandom)
        {

            if (User.Identity.IsAuthenticated)
            {
                return View("Error");
            }
            else
            {
                var result = await _userService.Verify(phone, inputRandom);
                if (result.Message == "user not found")
                {
                    ModelState.AddModelError("", _localizer["This account hasn't been verified"]);
                    return View(inputRandom);
                }
                if (result.Message == "rantom not found")
                {
                    ModelState.AddModelError("", _localizer["Email or Password is incorrect"]);

                    return View(phone);

                }
                if (result.Message == "random not match")
                {
                    ModelState.AddModelError("", _localizer["Please Try again few minutes later"]);
                    return View(inputRandom);
                }
                return RedirectToAction("Login", "Account");

            }
        }
        [HttpPost]
        public async Task<IActionResult> LogOut(string url)
        {
            var result = await _userService.LogOut();
            if (result.Success)
            {
                return LocalRedirect(url);
            }
            return View();
        }
        public async Task<IActionResult> Profile()
        {
            var user = await _userService.GetLoggedUser();
            var homes = await _homeService.GetHomesByUserId();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            var result = await _userService.LogIn(loginUser);
            if (result.Message == "user not verified")
            {
                ModelState.AddModelError("", _localizer["This account hasn't been verified"]);
                return View(loginUser);
            }
            if (result.Message == "user not found")
            {
                ModelState.AddModelError("", _localizer["Email or Password is incorrect"]);

                return View(loginUser);

            }
            if (result.Message == "loginfiled")
            {
                ModelState.AddModelError("", _localizer["Please Try again few minutes later"]);
                return View(loginUser);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            var result = await _userService.Register(registerUser);
            if (result.Message == "username alreadyused")
            {
                ModelState.AddModelError("", _localizer["This username is already registered"]);
                return View(registerUser);
            }
            if (registerUser.ConfirmPassword != registerUser.Password)
            {
                ModelState.AddModelError("", _localizer["Pasword and Conf Password"]);
                return View(registerUser);
            }
            if (result.Message == "email alreadyused")
            {
                ModelState.AddModelError("", _localizer["This email is already registered"]);
                return View(registerUser);
            }
            if (result.Message == "InvalidUserName")
            {
                ModelState.AddModelError("", _localizer["This account hasn't been verified"]);
                return View(registerUser);
            }


            return RedirectToAction("Verify", "Account", new { phone = registerUser.Phone });

        }
    }
}
