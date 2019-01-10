using CinemaSchedule.WebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaSchedule.WebSite.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult ScheduleEditor()
		{
			return View();
		}

		public IActionResult ScheduleViewer()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel
			{
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}
	}
}
