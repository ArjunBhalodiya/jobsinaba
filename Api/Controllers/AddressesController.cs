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
using JobsInABA.DAL.Repositories;
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;

namespace Api.Controllers
{
    public class AddressesController : ApiController
    {
        private AddressWorkflows db = new AddressWorkflows();

        // GET: api/Addresses
        public IEnumerable<AddressDataModel> GetAddresses()
        {
            return db.GetAddresses();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddressDataModel))]
        public IHttpActionResult GetAddress(int id)
        {
            AddressDataModel address = db.GetAddress(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            try
            {
                //db.UpdateAddress(id, address);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(AddressDataModel))]
        public IHttpActionResult PostAddress(AddressDataModel address)
        {
            db.Create(address);

            return CreatedAtRoute("DefaultApi", new { id = address.AddressID }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(AddressDataModel))]
        public IHttpActionResult DeleteAddress(int id)
        {
            //var address = db.DeleteAddress(id);

            return Ok();
        }

        private bool AddressExists(int id)
        {
            return (db.GetAddress(id) != null);
        }
    }
}