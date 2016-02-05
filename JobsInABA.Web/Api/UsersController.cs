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
using JobsInABA.Web.Services;
using JobsInABA.DAL.Repositories;

namespace JobsInABA.Web.Api
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private UsersRepo _user = new UsersRepo();

        // GET: api/Users
        [Route("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _user.GetUsers();
        }

        // GET: api/Users/5
        [Route("GetUsersByID")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            if (id == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            User user = _user.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [Route("UpdateUsers")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (id == null || user == null || id != user.UserID)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _user.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [Route("AddUsers")]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (user == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _user.CreateUser(user);

            EmailService.SendPasswordResetEmail(user.UserName, user.UserName);

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [Route("DeleteUsers")]
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            if (id == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            var result = _user.DeleteUser(id);

            return Ok(result);
        }

        private bool UserExists(int id)
        {
            return _user.GetUsers().Count(e => e.UserID == id) > 0;
        }
    }
}