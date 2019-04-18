using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Forma_Gym.DTOs;
using Forma_Gym.Models;

namespace Forma_Gym.Services
{
    public class SubscribersController : ApiController
    {
        private ApplicationDbContext _db ;
		public SubscribersController()
		{
			_db = new ApplicationDbContext();
		}

		// GET: api/Subscribers
		[HttpGet]
		public IHttpActionResult GetSubscribers(string query= null)
        {
			var subscriber = _db.Subscribers.Include(c => c.Subscription);

			if (!string.IsNullOrWhiteSpace(query))
				subscriber = subscriber.Where(c => c.Name.Contains(query));

			var subscriberDto= subscriber
				.Select(Mapper.Map<Subscriber, SubscriberDto>).ToList();

			return Ok(subscriberDto);
        }

        // GET: api/Subscribers/id
        [ResponseType(typeof(SubscriberDto))]
		[HttpGet]
        public IHttpActionResult GetSubscriber(int id)
        {
            var subscriber = _db.Subscribers.SingleOrDefault(c=>c.Id==id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Subscriber, SubscriberDto>(subscriber));
        }

        // PUT: api/Subscribers/id
        [ResponseType(typeof(void))]
		[HttpPut]
		[Authorize(Roles = RoleName.ManageActivities)]
		public IHttpActionResult PutSubscriber(int id, SubscriberDto subscriberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			var subscriber = _db.Subscribers.SingleOrDefault(c=>c.Id==id);
			if (subscriber == null)
			{
				return NotFound();
			}
			Mapper.Map(subscriberDto, subscriber);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
				throw ex;
            }

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/Subscribers
		[ResponseType(typeof(SubscriberDto))]
		[HttpPost]
		[Authorize(Roles = RoleName.ManageActivities)]
		public IHttpActionResult PostSubscriber(SubscriberDto subscriberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			var subscriber = Mapper.Map<SubscriberDto, Subscriber>(subscriberDto);

			_db.Subscribers.Add(subscriber);
            _db.SaveChanges();

            return Created(new Uri (Request.RequestUri+ "/"+ subscriber.Id)  , subscriber);

		}

        // DELETE: api/Subscribers/id
        [ResponseType(typeof(void))]
		[HttpDelete]
		[Authorize(Roles = RoleName.ManageActivities)]
		public IHttpActionResult DeleteSubscriber(int id)
        {
            var subscriber = _db.Subscribers.SingleOrDefault(c=>c.Id==id);

			if (subscriber == null)
            {
                return NotFound();
            }

            _db.Subscribers.Remove(subscriber);
            _db.SaveChanges();

			return StatusCode(HttpStatusCode.NoContent);

		}

        
        private bool SubscriberExists(int id)
        {
            return _db.Subscribers.Count(e => e.Id == id) > 0;
        }
    }
}