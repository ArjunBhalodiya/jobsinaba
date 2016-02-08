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
    public class UserPhonesController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/UserPhones
        public IQueryable<UserPhone> GetUserPhones()
        {
            return db.UserPhones;
        }

        // GET: api/UserPhones/5
        [ResponseType(typeof(UserPhone))]
        public IHttpActionResult GetUserPhone(int id)
        {
            UserPhone userPhone = db.UserPhones.Find(id);
            if (userPhone == null)
            {
                return NotFound();
            }

            return Ok(userPhone);
        }

        // PUT: api/UserPhones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserPhone(int id, UserPhone userPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userPhone.UserPhoneID)
            {
                return BadRequest();
            }

            db.Entry(userPhone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPhoneExists(id))
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

        // POST: api/UserPhones
        [ResponseType(typeof(UserPhone))]
        public IHttpActionResult PostUserPhone(UserPhone userPhone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserPhones.Add(userPhone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userPhone.UserPhoneID }, userPhone);
        }

        // DELETE: api/UserPhones/5
        [ResponseType(typeof(UserPhone))]
        public IHttpActionResult DeleteUserPhone(int id)
        {
            UserPhone userPhone = db.UserPhones.Find(id);
            if (userPhone == null)
            {
                return NotFound();
            }

            db.UserPhones.Remove(userPhone);
            db.SaveChanges();

            return Ok(userPhone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserPhoneExists(int id)
        {
            return db.UserPhones.Count(e => e.UserPhoneID == id) > 0;
        }
    }
}