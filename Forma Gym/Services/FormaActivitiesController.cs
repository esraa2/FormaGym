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
    public class FormaActivitiesController : ApiController
    {
        private ApplicationDbContext _db ;
		public FormaActivitiesController()
		{
			_db = new ApplicationDbContext();
		}

		// GET: api/FormaActivities
		[HttpGet]
		public IHttpActionResult GetActiviies(string query= null)
        {

			var activity = _db.Activiies.Include(c => c.Class);
				

			if (!string.IsNullOrWhiteSpace(query))
				activity = activity.Where(c=>c.Name.Contains(query));
			
			var activityDto = activity
				.Select(Mapper.Map<FormaActivity, FormaActivityDto>).ToList();

			return Ok(activityDto);
		}

        // GET: api/FormaActivities/id
		[HttpGet]
        [ResponseType(typeof(FormaActivityDto))]
        public IHttpActionResult GetFormaActivity(int id)
        {
            var formaActivity = _db.Activiies.SingleOrDefault(c=>c.Id== id);
            if (formaActivity == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<FormaActivity,FormaActivityDto>(formaActivity));
        }

        // PUT: api/FormaActivities/id
		[HttpPut]
		[Authorize(Roles = RoleName.ManageActivities)]
		[ResponseType(typeof(void))]
        public IHttpActionResult PutFormaActivity(int id, FormaActivityDto formaActivityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			var formaActivity = _db.Activiies.SingleOrDefault(c=>c.Id==id);
			if (formaActivity == null)
			{
				return NotFound();
			}
			Mapper.Map(formaActivityDto, formaActivity);

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

        // POST: api/FormaActivities
        [ResponseType(typeof(FormaActivityDto))]
		[HttpPost]
		[Authorize(Roles = RoleName.ManageActivities)]
		public IHttpActionResult PostFormaActivity(FormaActivityDto formaActivityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			var formaActivity = Mapper.Map<FormaActivityDto,FormaActivity>(formaActivityDto);

			_db.Activiies.Add(formaActivity);
            _db.SaveChanges();

            return Created(new Uri(Request.RequestUri +"/"+ formaActivity.Id ), formaActivity);
        }

        // DELETE: api/FormaActivities/id
        [ResponseType(typeof(void))]
		[Authorize(Roles = RoleName.ManageActivities)]
		[HttpDelete]
        public IHttpActionResult DeleteFormaActivity(int id)
        {
            var formaActivity = _db.Activiies.SingleOrDefault(c=>c.Id==id);

			if (formaActivity == null)
            {
                return NotFound();
            }

            _db.Activiies.Remove(formaActivity);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool FormaActivityExists(int id)
        {
            return _db.Activiies.Count(e => e.Id == id) > 0;
        }
    }
}