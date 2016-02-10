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

namespace JobsInABA.DAL.Repositories
{
    public class BusinessesRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Business> GetBusinesses()
        {
            return db.Businesses;
        }

        public Business GetBusiness(int id)
        {
            Business business = db.Businesses.Find(id);
            return business;
        }

        public void UpdateBusiness(int id, Business business)
        {
            db.Entry(business).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Business PostBusiness(Business business)
        {
            db.Businesses.Add(business);
            db.SaveChanges();

            return business;
        }

        public Business DeleteBusiness(int id)
        {
            Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return null;
            }

            db.Businesses.Remove(business);
            db.SaveChanges();

            return business;
        }

        private bool BusinessExists(int id)
        {
            return db.Businesses.Count(e => e.BusinessID == id) > 0;
        }
    }
}