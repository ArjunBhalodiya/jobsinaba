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
    public class JobApplicationsController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/JobApplications
        public IQueryable<JobApplication> GetJobApplications()
        {
            return db.JobApplications;
        }

        // GET: api/JobApplications/5
        [ResponseType(typeof(JobApplication))]
        public IHttpActionResult GetJobApplication(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return Ok(jobApplication);
        }

        // PUT: api/JobApplications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobApplication(int id, JobApplication jobApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobApplication.JobApplicationID)
            {
                return BadRequest();
            }

            db.Entry(jobApplication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationExists(id))
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

        // POST: api/JobApplications
        [ResponseType(typeof(JobApplication))]
        public IHttpActionResult PostJobApplication(JobApplication jobApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobApplications.Add(jobApplication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobApplication.JobApplicationID }, jobApplication);
        }

        // DELETE: api/JobApplications/5
        [ResponseType(typeof(JobApplication))]
        public IHttpActionResult DeleteJobApplication(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            db.JobApplications.Remove(jobApplication);
            db.SaveChanges();

            return Ok(jobApplication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobApplicationExists(int id)
        {
            return db.JobApplications.Count(e => e.JobApplicationID == id) > 0;
        }
    }
}