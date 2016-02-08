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
    public class UserEmailsController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/UserEmails
        public IQueryable<UserEmail> GetUserEmails()
        {
            return db.UserEmails;
        }

        // GET: api/UserEmails/5
        [ResponseType(typeof(UserEmail))]
        public IHttpActionResult GetUserEmail(int id)
        {
            UserEmail userEmail = db.UserEmails.Find(id);
            if (userEmail == null)
            {
                return NotFound();
            }

            return Ok(userEmail);
        }

        // PUT: api/UserEmails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserEmail(int id, UserEmail userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userEmail.UserEmailID)
            {
                return BadRequest();
            }

            db.Entry(userEmail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEmailExists(id))
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

        // POST: api/UserEmails
        [ResponseType(typeof(UserEmail))]
        public IHttpActionResult PostUserEmail(UserEmail userEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserEmails.Add(userEmail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userEmail.UserEmailID }, userEmail);
        }

        // DELETE: api/UserEmails/5
        [ResponseType(typeof(UserEmail))]
        public IHttpActionResult DeleteUserEmail(int id)
        {
            UserEmail userEmail = db.UserEmails.Find(id);
            if (userEmail == null)
            {
                return NotFound();
            }

            db.UserEmails.Remove(userEmail);
            db.SaveChanges();

            return Ok(userEmail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserEmailExists(int id)
        {
            return db.UserEmails.Count(e => e.UserEmailID == id) > 0;
        }
    }
}