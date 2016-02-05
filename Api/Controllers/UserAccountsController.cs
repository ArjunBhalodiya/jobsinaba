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

namespace Api.Controllers
{
    public class UserAccountsController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        // GET: api/UserAccounts
        public IQueryable<UserAccount> GetUserAccounts()
        {
            return db.UserAccounts;
        }

        // GET: api/UserAccounts/5
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult GetUserAccount(int id)
        {
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount);
        }

        // PUT: api/UserAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAccount(int id, UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAccount.UserAccountID)
            {
                return BadRequest();
            }

            db.Entry(userAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(id))
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

        // POST: api/UserAccounts
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult PostUserAccount(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAccounts.Add(userAccount);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userAccount.UserAccountID }, userAccount);
        }

        // DELETE: api/UserAccounts/5
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult DeleteUserAccount(int id)
        {
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            db.UserAccounts.Remove(userAccount);
            db.SaveChanges();

            return Ok(userAccount);
        }

        // DELETE: api/UserAccounts/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult SignIn(string email, string password)
        {
            byte[] bytes = new byte[password.Length * sizeof(char)];
            System.Buffer.BlockCopy(password.ToCharArray(), 0, bytes, 0, bytes.Length);

            return (db.UserAccounts.Count(p => p.UserName == email && p.Password == bytes) > 0 ? Ok(true) : Ok(false));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAccountExists(int id)
        {
            return db.UserAccounts.Count(e => e.UserAccountID == id) > 0;
        }
    }
}