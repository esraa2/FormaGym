using Forma_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forma_Gym.Controllers
{
	[Authorize(Roles = RoleName.ManageActivities)]
	public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }
    }
}