using Microsoft.AspNetCore.Mvc;

namespace Letter.WebUI.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
	}
}
