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
    public class BusinessPhonesController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/BusinessPhones
        public IQueryable<BusinessPhone> GetBusinessPhones()
        {
            return db.BusinessPhones;
        }

        // GET: api/BusinessPhones/5
        [ResponseType(typeof(BusinessPhone))]
        public IHttpActionResult GetBusinessPhone(int id)
        {
            BusinessPhone businessPhone = db.BusinessPhones.Find(id);
            if (businessPhone == null)
            {
                return NotFound();
            }

            return Ok(businessPhone);
        }

        // PUT: api/BusinessPhones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessPhone(int id, BusinessPhone businessPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessPhone.BusinessPhoneID)
            {
                return BadRequest();
            }

            db.Entry(businessPhone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessPhoneExists(id))
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

        // POST: api/BusinessPhones
        [ResponseType(typeof(BusinessPhone))]
        public IHttpActionResult PostBusinessPhone(BusinessPhone businessPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusinessPhones.Add(businessPhone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = businessPhone.BusinessPhoneID }, businessPhone);
        }

        // DELETE: api/BusinessPhones/5
        [ResponseType(typeof(BusinessPhone))]
        public IHttpActionResult DeleteBusinessPhone(int id)
        {
            BusinessPhone businessPhone = db.BusinessPhones.Find(id);
            if (businessPhone == null)
            {
                return NotFound();
            }

            db.BusinessPhones.Remove(businessPhone);
            db.SaveChanges();

            return Ok(businessPhone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessPhoneExists(int id)
        {
            return db.BusinessPhones.Count(e => e.BusinessPhoneID == id) > 0;
        }
    }
}