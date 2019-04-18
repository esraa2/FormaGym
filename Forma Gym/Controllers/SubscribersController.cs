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
    public class SubscribersController : Controller
    {
        private ApplicationDbContext _db;

		public SubscribersController()
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

		// GET: Subscribers
		public ActionResult Index()
        {
			if (User.IsInRole("ManageActivities"))
				return View("List");
			return View("ReadOnlyList");
		}

        // GET: Subscribers/Details/id
        public ActionResult Details(int id)
        {
            var subscriber = _db.Subscribers.Include(c=>c.Subscription).SingleOrDefault(c=>c.Id==id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

		// GET: Subscribers/Create
		[Authorize(Roles = "ManageActivities")]
		public ActionResult Create()
        {
			var viewmodel = new SubscriberAndSubscriptions
			{
				Subscriptions = _db.Subscription.ToList(),
				Subscriber = new Subscriber()
			};

			return View("Create",viewmodel);
        }

        // POST: Subscribers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ManageActivities")]
		public ActionResult Create(Subscriber subscriber)
        {
			if (ModelState.IsValid)
			{
				if (subscriber.Id == 0)
				{
					_db.Subscribers.Add(subscriber);
				}
				else
				{
					var subscriberInDb = _db.Subscribers.SingleOrDefault(c=>c.Id== subscriber.Id);
					subscriberInDb.Name = subscriber.Name;
					subscriberInDb.BirthDate = subscriber.BirthDate;
					subscriberInDb.SubscriptionId = subscriber.SubscriptionId;

				}
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

		}

		// GET: Subscribers/Edit/id
		[Authorize(Roles = "ManageActivities")]
		public ActionResult Edit(int id)
        {
            var subscriber = _db.Subscribers.SingleOrDefault(c=>c.Id==id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
			var viewmodel = new SubscriberAndSubscriptions
			{
				Subscriber=subscriber,
				Subscriptions=_db.Subscription.ToList()
			};
			return View("Create", viewmodel);
		}

		// GET: Subscribers/Delete/id
		[Authorize(Roles = "ManageActivities")]
		public ActionResult Delete(int id)
        {
            var subscriber = _db.Subscribers.SingleOrDefault(c=>c.Id==id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
			_db.Subscribers.Remove(subscriber);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}
