using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Forma_Gym.Controllers
{
	[AllowAnonymous]
	[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}
	}
}