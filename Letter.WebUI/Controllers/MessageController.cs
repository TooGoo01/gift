using Microsoft.AspNetCore.Mvc;

namespace Letter.WebUI.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Create()
		{
			return View();
		}
		public IActionResult Preview()
		{
			return View();
		}
	}
}
