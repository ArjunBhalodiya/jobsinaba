using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobsInABA.DTOs;
using JobsInABA.BL;
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;
using JobsInABA.DAL;
using JobsInABA.DAL.Entities;

namespace Api.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<UserDataModel> Get()
        {
            UserWorkflows oUserWorkflows = new UserWorkflows();
            List<UserDataModel> oUserDataModels = oUserWorkflows.GetUsers();
            return oUserDataModels;
        }

        /*
        // GET api/<controller>/5
        public UserDTO Get(int id)
        {
            UsersBL oUsersBL = new UsersBL();
            UserDTO oUserDTO = oUsersBL.Get(id);
            return oUserDTO;
        }
        */
        // GET api/<controller>/5
        public UserDataModel Get(int id)
        {
            UserWorkflows oUserWorkflows = new UserWorkflows();
            UserDataModel oUserDataModel = oUserWorkflows.GetUser(id);
            return oUserDataModel;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
           
            UsersBL oUsersBL = new UsersBL();

            UserDTO u = new UserDTO
            {
                FirstName = "Arjun User",
                MiddleName = "A",
                LastName = "Test",
                UserName = "thirdusertest",
                DOB = new DateTime(2011, 12, 1),
                IsActive = true,
                IsDeleted = false,
                insdt = DateTime.Now,
                upddt = DateTime.Now,
                insuser = 3,
                upduser = 3
            };

            UserDTO usr = oUsersBL.Create(u);
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}