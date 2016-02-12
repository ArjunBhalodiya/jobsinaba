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
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;

namespace JobsInABA.Web.Api
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private UserWorkflows _user = new UserWorkflows();

        // GET: api/Users
        //[Route("GetUsers")]
        public List<UserDataModel> Get()
        {
            return _user.GetUsers();
        }

        // GET: api/Users/5
        //[Route("GetUsersByID")]
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult Get(int id)
        {
            UserDataModel dataModel = _user.GetUser(id);
            if (dataModel == null)
            {
                return NotFound();
            }

            return Ok(dataModel);
        }

        // PUT: api/Users/5
        [Route("UpdateUsers")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UserDataModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != user.UserID)
            {
                return StatusCode(HttpStatusCode.BadRequest);
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
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult PostUser(UserDataModel user)
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
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult DeleteUser(int id)
        {
            var result = _user.DeleteUser(id);

            return Ok(result);
        }

        private bool UserExists(int id)
        {
            return _user.GetUsers().Count(e => e.UserID == id) > 0;
        }
    }
}