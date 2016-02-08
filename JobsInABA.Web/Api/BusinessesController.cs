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
using JobsInABA.Web.Models;

namespace JobsInABA.Web.Api
{
    [RoutePrefix("api/Business")]
    public class BusinessesController : ApiController
    {
        private BusinessRepo _business = new BusinessRepo();

        // GET: api/Businesses
        public IEnumerable<Business> GetBusinesses()
        {
            return _business.GetBusinesss();
        }

        // GET: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult GetBusinessByID(int id)
        {
            Business business = _business.GetBusinessByID(id);
            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        // PUT: api/Businesses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusiness(int id, Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business.BusinessID)
            {
                return BadRequest();
            }

            try
            {
                _business.UpdateBusiness(business);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        [ResponseType(typeof(Business))]
        public IHttpActionResult PostBusiness(Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _business.CreateBusiness(business);

            return CreatedAtRoute("DefaultApi", new { id = business.BusinessID }, business);
        }

        // DELETE: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult DeleteBusiness(int id)
        {
            Business business = _business.GetBusinessByID(id);
            if (business == null)
            {
                return NotFound();
            }

            _business.DeleteBusiness(id);

            return Ok(business);
        }

        private bool BusinessExists(int id)
        {
            return _business.GetBusinesss().Count(e => e.BusinessID == id) > 0;
        }
    }
}