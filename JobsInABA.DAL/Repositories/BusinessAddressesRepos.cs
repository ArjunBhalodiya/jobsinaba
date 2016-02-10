using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using JobsInABA.DAL.Entities;

namespace JobsInABA.DAL.Repositories
{
    public class BusinessAddressesRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessAddress> GetBusinessAddresses()
        {
            return db.BusinessAddresses;
        }

        public BusinessAddress GetBusinessAddress(int id)
        {
            BusinessAddress businessAddress = db.BusinessAddresses.Find(id);
            return businessAddress;
        }

        public void UpdateBusinessAddress(int id, BusinessAddress businessAddress)
        {
            db.Entry(businessAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessAddress CreateBusinessAddress(BusinessAddress businessAddress)
        {
            db.BusinessAddresses.Add(businessAddress);
            db.SaveChanges();

            return businessAddress;
        }

        public BusinessAddress DeleteBusinessAddress(int id)
        {
            BusinessAddress businessAddress = db.BusinessAddresses.Find(id);
            if (businessAddress == null)
            {
                return null;
            }

            db.BusinessAddresses.Remove(businessAddress);
            db.SaveChanges();

            return businessAddress;
        }

        private bool BusinessAddressExists(int id)
        {
            return db.BusinessAddresses.Count(e => e.BusinessAddressID == id) > 0;
        }
    }
}