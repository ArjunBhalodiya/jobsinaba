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
using JobsInABA.DAL.Entities;

namespace JobsInABA.Web.Api
{
    public class JobApplicationStatesController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/JobApplicationStates
        public IQueryable<JobApplicationState> GetJobApplicationStates()
        {
            return db.JobApplicationStates;
        }

        // GET: api/JobApplicationStates/5
        [ResponseType(typeof(JobApplicationState))]
        public IHttpActionResult GetJobApplicationState(int id)
        {
            JobApplicationState jobApplicationState = db.JobApplicationStates.Find(id);
            if (jobApplicationState == null)
            {
                return NotFound();
            }

            return Ok(jobApplicationState);
        }

        // PUT: api/JobApplicationStates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobApplicationState(int id, JobApplicationState jobApplicationState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobApplicationState.JobApplicationStateID)
            {
                return BadRequest();
            }

            db.Entry(jobApplicationState).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationStateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/JobApplicationStates
        [ResponseType(typeof(JobApplicationState))]
        public IHttpActionResult PostJobApplicationState(JobApplicationState jobApplicationState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobApplicationStates.Add(jobApplicationState);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobApplicationState.JobApplicationStateID }, jobApplicationState);
        }

        // DELETE: api/JobApplicationStates/5
        [ResponseType(typeof(JobApplicationState))]
        public IHttpActionResult DeleteJobApplicationState(int id)
        {
            JobApplicationState jobApplicationState = db.JobApplicationStates.Find(id);
            if (jobApplicationState == null)
            {
                return NotFound();
            }

            db.JobApplicationStates.Remove(jobApplicationState);
            db.SaveChanges();

            return Ok(jobApplicationState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobApplicationStateExists(int id)
        {
            return db.JobApplicationStates.Count(e => e.JobApplicationStateID == id) > 0;
        }
    }
}