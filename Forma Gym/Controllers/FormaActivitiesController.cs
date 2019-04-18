using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forma_Gym.Models;
using Forma_Gym.ViewModel;

namespace Forma_Gym.Controllers
{
    public class FormaActivitiesController : Controller
    {
        private ApplicationDbContext _db ;

		public FormaActivitiesController()
		{
			_db = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		// GET: FormaActivities
		public ActionResult Index()
        {
			if (User.IsInRole(RoleName.ManageActivities))
				return View("List");
            return View("ReadOnlyList");
        }

        // GET: FormaActivities/Details/id
        public ActionResult Details(int id)
        {
            var formaActivity = _db.Activiies.Include(c=>c.Class).SingleOrDefault(c=>c.Id==id);
            if (formaActivity == null)
            {
                return HttpNotFound();
            }
            return View(formaActivity);
        }

        // GET: FormaActivities/Create
		[Authorize(Roles = RoleName.ManageActivities)]
        public ActionResult Create()
        {
			var viewmodel = new FormaActivityAndClasses
			{
				FormaActivity = new FormaActivity(),
				Classes = _db.Classes.ToList()
			};
			return View("Create", viewmodel);
        }

        // POST: FormaActivities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.ManageActivities)]
		public ActionResult Create(FormaActivity formaActivity)
        {
            if (ModelState.IsValid)
            {
				if (formaActivity.Id == 0)
				{
					_db.Activiies.Add(formaActivity);
				}
				else
				{
					var formaActivityInDb = _db.Activiies.SingleOrDefault(c=>c.Id== formaActivity.Id);
					formaActivityInDb.Name = formaActivity.Name;
					formaActivityInDb.ClassDuration = formaActivity.ClassDuration;
					formaActivityInDb.TrainerName = formaActivity.TrainerName;
					formaActivityInDb.ClassId = formaActivity.ClassId;
				}
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		}

		// GET: FormaActivities/Edit/id
		[Authorize(Roles = RoleName.ManageActivities)]
		public ActionResult Edit(int id)
        {
            var formaActivity = _db.Activiies.SingleOrDefault(c=>c.Id==id);
            if (formaActivity == null)
            {
                return HttpNotFound();
            }
			var viewmodel = new FormaActivityAndClasses {
				FormaActivity=formaActivity,
				Classes= _db.Classes.ToList()
			};

			 return View("Create",viewmodel);
        }

		// DeleteGet: FormaActivities/Delete/id
		[Authorize(Roles = RoleName.ManageActivities)]
		public ActionResult Delete(int id)
        {
            var formaActivity = _db.Activiies.SingleOrDefault(c=>c.Id==id);
            if (formaActivity == null)
            {
                return HttpNotFound();
            }
            return View(formaActivity);
        }

        // DeletePOST: FormaActivities/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = RoleName.ManageActivities)]
		public ActionResult DeleteConfirmed(int id)
        {
            var formaActivity = _db.Activiies.SingleOrDefault(c=>c.Id==id);
            _db.Activiies.Remove(formaActivity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
