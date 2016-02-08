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
    public class UserAddressesController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/UserAddresses
        public IQueryable<UserAddress> GetUserAddresses()
        {
            return db.UserAddresses;
        }

        // GET: api/UserAddresses/5
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult GetUserAddress(int id)
        {
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return Ok(userAddress);
        }

        // PUT: api/UserAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAddress(int id, UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAddress.UserAddressID)
            {
                return BadRequest();
            }

            db.Entry(userAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(id))
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

        // POST: api/UserAddresses
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult PostUserAddress(UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAddresses.Add(userAddress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userAddress.UserAddressID }, userAddress);
        }

        // DELETE: api/UserAddresses/5
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult DeleteUserAddress(int id)
        {
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return NotFound();
            }

            db.UserAddresses.Remove(userAddress);
            db.SaveChanges();

            return Ok(userAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAddressExists(int id)
        {
            return db.UserAddresses.Count(e => e.UserAddressID == id) > 0;
        }
    }
}