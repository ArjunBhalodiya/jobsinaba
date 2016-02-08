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
    public class BusinessAddressesController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/BusinessAddresses
        public IQueryable<BusinessAddress> GetBusinessAddresses()
        {
            return db.BusinessAddresses;
        }

        // GET: api/BusinessAddresses/5
        [ResponseType(typeof(BusinessAddress))]
        public IHttpActionResult GetBusinessAddress(int id)
        {
            BusinessAddress businessAddress = db.BusinessAddresses.Find(id);
            if (businessAddress == null)
            {
                return NotFound();
            }

            return Ok(businessAddress);
        }

        // PUT: api/BusinessAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusinessAddress(int id, BusinessAddress businessAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != businessAddress.BusinessAddressID)
            {
                return BadRequest();
            }

            db.Entry(businessAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessAddressExists(id))
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

        // POST: api/BusinessAddresses
        [ResponseType(typeof(BusinessAddress))]
        public IHttpActionResult PostBusinessAddress(BusinessAddress businessAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BusinessAddresses.Add(businessAddress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = businessAddress.BusinessAddressID }, businessAddress);
        }

        // DELETE: api/BusinessAddresses/5
        [ResponseType(typeof(BusinessAddress))]
        public IHttpActionResult DeleteBusinessAddress(int id)
        {
            BusinessAddress businessAddress = db.BusinessAddresses.Find(id);
            if (businessAddress == null)
            {
                return NotFound();
            }

            db.BusinessAddresses.Remove(businessAddress);
            db.SaveChanges();

            return Ok(businessAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessAddressExists(int id)
        {
            return db.BusinessAddresses.Count(e => e.BusinessAddressID == id) > 0;
        }
    }
}