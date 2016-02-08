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

namespace JobsInABA.Web.Api
{
    [RoutePrefix("api/Addresses")]
    public class AddressesController : ApiController
    {
        private AddressRepo _address = new AddressRepo();

        // GET: api/Addresses
        [Route("GetAddresses")]
        public IEnumerable<Address> GetAddresses()
        {
            return _address.GetAddress();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Address))]
        [Route("GetAddressesByID")]
        public IHttpActionResult GetAddress(int id)
        {
            Address address = _address.GetAddressByID(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [Route("UpdateAddresses")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.AddressID)
            {
                return BadRequest();
            }

            try
            {
                _address.UpdateAddress(address);
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
        [Route("AddAddresses")]
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _address.CreateAddress(address);
            
            return CreatedAtRoute("DefaultApi", new { id = address.AddressID }, address);
        }

        // DELETE: api/Addresses/5
        [Route("DeleteAddresses")]
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = _address.GetAddressByID(id);
            if (address == null)
            {
                return NotFound();
            }

            _address.DeleteAddress(id);

            return Ok(address);
        }

        private bool AddressExists(int id)
        {
            return _address.GetAddress().Count(e => e.AddressID == id) > 0;
        }
    }
}