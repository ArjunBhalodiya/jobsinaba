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
    public class BusinessPhonesRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessPhone> GetBusinessPhones()
        {
            return db.BusinessPhones;
        }

        public BusinessPhone GetBusinessPhone(int id)
        {
            BusinessPhone businessPhone = db.BusinessPhones.Find(id);
            return businessPhone;
        }

        public void PutBusinessPhone(int id, BusinessPhone businessPhone)
        {
            db.Entry(businessPhone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessPhone PostBusinessPhone(BusinessPhone businessPhone)
        {
            db.BusinessPhones.Add(businessPhone);
            db.SaveChanges();

            return businessPhone;
        }

        public BusinessPhone DeleteBusinessPhone(int id)
        {
            BusinessPhone businessPhone = db.BusinessPhones.Find(id);
            if (businessPhone == null)
            {
                return null;
            }

            db.BusinessPhones.Remove(businessPhone);
            db.SaveChanges();

            return businessPhone;
        }

        private bool BusinessPhoneExists(int id)
        {
            return db.BusinessPhones.Count(e => e.BusinessPhoneID == id) > 0;
        }
        
        protected void Dispose()
        {
            db.Dispose();
        }
    }
}