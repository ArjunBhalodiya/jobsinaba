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
    public class EmailsRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Email> GetEmails()
        {
            return db.Emails;
        }

        public Email GetEmail(int id)
        {
            Email email = db.Emails.Find(id);
            return email;
        }

        public void PutEmail(int id, Email email)
        {
            db.Entry(email).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Email PostEmail(Email email)
        {
            db.Emails.Add(email);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return email;
        }

        public Email DeleteEmail(int id)
        {
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return null;
            }

            db.Emails.Remove(email);
            db.SaveChanges();

            return email;
        }

        private bool EmailExists(int id)
        {
            return db.Emails.Count(e => e.EmailID == id) > 0;
        }
    }
}