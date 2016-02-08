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
    public class BusinessEmailsController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/BusinessEmails
        public IQueryable<BusinessEmail> GetBusinessEmails()
        {
            return db.BusinessEmails;
        }

        // GET: api/BusinessEmails/5
        [ResponseType(typeof(BusinessEmail))]
        public IHttpActionResult GetBusinessEmail(int id)
        {
            BusinessEmail businessEmail = db.BusinessEmails.Find(id);
            if (businessEmail == null)
            {
                return NotFound();
            }

            return Ok(businessEmail);
        }

        // PUT: api/BusinessEmails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessEmail(int id, BusinessEmail businessEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessEmail.BusinessEmailID)
            {
                return BadRequest();
            }

            db.Entry(businessEmail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessEmailExists(id))
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

        // POST: api/BusinessEmails
        [ResponseType(typeof(BusinessEmail))]
        public IHttpActionResult PostBusinessEmail(BusinessEmail businessEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusinessEmails.Add(businessEmail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = businessEmail.BusinessEmailID }, businessEmail);
        }

        // DELETE: api/BusinessEmails/5
        [ResponseType(typeof(BusinessEmail))]
        public IHttpActionResult DeleteBusinessEmail(int id)
        {
            BusinessEmail businessEmail = db.BusinessEmails.Find(id);
            if (businessEmail == null)
            {
                return NotFound();
            }

            db.BusinessEmails.Remove(businessEmail);
            db.SaveChanges();

            return Ok(businessEmail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessEmailExists(int id)
        {
            return db.BusinessEmails.Count(e => e.BusinessEmailID == id) > 0;
        }
    }
}