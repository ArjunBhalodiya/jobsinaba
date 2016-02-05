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
using System.Text;
using System.Web;
using JobsInABA.DAL.Repositories;

namespace JobsInABA.Web.Api
{
    [RoutePrefix("api/UserAccount")]
    public class UserAccountsController : ApiController
    {
        private UserAccountRepo _user = new UserAccountRepo();

        // GET: api/UserAccounts
        [Route("GetUserAccount")]
        public IEnumerable<UserAccount> GetUserAccounts()
        {
            return _user.GetUserAccount();
        }

        // GET: api/UserAccounts/5
        [Route("GetUserAccountByID")]
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult GetUserAccount(int id)
        {
            if (id == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = _user.GetUserAccountByID(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount);
        }

        // PUT: api/UserAccounts/5
        [Route("UpdateUserAccount")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAccount(int id, UserAccount userAccount)
        {
            if (id == null || userAccount == null || id != userAccount.UserAccountID)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _user.UpdateUserAccount(userAccount);
            }
            catch (DBConcurrencyException)
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
        [Route("AddUserAccount")]
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult PostUserAccount(string UserName, string Password)
        {
            if (UserName == null || Password == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = new UserAccount();
            userAccount.UserName = UserName;
            userAccount.IsActive = false;
            userAccount.IsDeleted = false;
            userAccount.Password = Encoding.ASCII.GetBytes(Password);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _user.CreateUserAccount(userAccount);

            return CreatedAtRoute("DefaultApi", new { id = userAccount.UserAccountID }, userAccount);
        }

        // DELETE: api/UserAccounts/5
        [Route("DeleteUserAccount")]
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult DeleteUserAccount(int id)
        {
            if (id == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = _user.GetUserAccountByID(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _user.DeleteUserAccount(id);

            return Ok(userAccount);
        }

        [Route("SignIn")]
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult SignIn(string username, string password)
        {
            if (username == null || password == null)
                return StatusCode(HttpStatusCode.BadRequest);

            byte[] passwordInBytes = Encoding.ASCII.GetBytes(password);
            var user = _user.GetUserAccount().FirstOrDefault(p => p.UserName == username && p.Password == passwordInBytes);

            if (user == null)
            {
                return NotFound();
            }
            else if (user.IsActive)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [Route("ActivateAccount")]
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult ActivateAccount(int id)
        {
            if (id == null)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            var user = _user.GetUserAccountByID(id);

            if (user == null)
            {
                NotFound();
            }

            user.IsActive = true;
            _user.UpdateUserAccount(user);

            return Ok(true);
        }

        private bool UserAccountExists(int id)
        {
            return _user.GetUserAccount().Count(e => e.UserAccountID == id) > 0;
        }
    }
}