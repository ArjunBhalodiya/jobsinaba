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
    public class BusinessEmailsRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessEmail> GetBusinessEmails()
        {
            return db.BusinessEmails;
        }

        public BusinessEmail GetBusinessEmail(int id)
        {
            BusinessEmail businessEmail = db.BusinessEmails.Find(id);
            return businessEmail;
        }

        public void PutBusinessEmail(int id, BusinessEmail businessEmail)
        {
            db.Entry(businessEmail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessEmail AddBusinessEmail(BusinessEmail businessEmail)
        {
            db.BusinessEmails.Add(businessEmail);
            db.SaveChanges();
            return businessEmail;
        }

        public BusinessEmail DeleteBusinessEmail(int id)
        {
            BusinessEmail businessEmail = db.BusinessEmails.Find(id);
            if (businessEmail == null)
            {
                return null;
            }

            db.BusinessEmails.Remove(businessEmail);
            db.SaveChanges();

            return businessEmail;
        }

        private bool BusinessEmailExists(int id)
        {
            return db.BusinessEmails.Count(e => e.BusinessEmailID == id) > 0;
        }
    }
}