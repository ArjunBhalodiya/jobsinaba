using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using JobsInABA.DAL.Entities;
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;

namespace Api.Controllers
{
    public class UsersController : ApiController
    {
        private UserWorkflows db = new UserWorkflows();

        // GET: api/Users
        public IEnumerable<UserDataModel> GetUsers()
        {
            return db.GetUsers();
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult GetUser(int id)
        {
            UserDataModel user = db.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UserDataModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateUser(user);
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
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult PostUser(UserDataModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreateUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(db.DeleteUser(id));
        }

        private bool UserExists(int id)
        {
            return db.GetUser(id) != null;
        }
    }
}