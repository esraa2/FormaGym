using Forma_Gym.DTOs;
using Forma_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forma_Gym.Services
{
    public class NewRentalController : ApiController
    {
		private ApplicationDbContext _db;
		public NewRentalController()
		{
			_db = new ApplicationDbContext();
		}

		[HttpPost]
		public IHttpActionResult PostNewRental(RentalDto RentalDto )
		{
			//if (RentalDto.ActivityIds.Count == 0)
			//	return BadRequest("there no activity available");

			var subscriber = _db.Subscribers
				.SingleOrDefault(c => c.Id == RentalDto.SubscriberId);

			if (subscriber == null)
				return NotFound();

			var activities = _db.Activiies
				.Where(m=>RentalDto.ActivityIds.Contains(m.Id)).ToList();

			//if (activities.Count != RentalDto.ActivityIds.Count)
			//	return BadRequest("one or more of activities not loaded ");

			foreach (var activity in activities)
			{

				var rental = new Rental
				{
					Subscriber = subscriber,
					Activity = activity,
					DateRented = DateTime.Now
				};
				_db.Rentals.Add(rental);
			}

			_db.SaveChanges();
			return Ok();
		}
    }
}
