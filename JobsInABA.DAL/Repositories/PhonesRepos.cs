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
    public class PhonesRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Phone> GetPhones()
        {
            return db.Phones;
        }

        public Phone GetPhone(int id)
        {
            Phone phone = db.Phones.Find(id);
            return phone;
        }

        public void UpdatePhone(int id, Phone phone)
        {
            db.Entry(phone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Phone AddPhone(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();

            return phone;
        }

        public Phone DeletePhone(int id)
        {
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return null;
            }

            db.Phones.Remove(phone);
            db.SaveChanges();

            return phone;
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.PhoneID == id) > 0;
        }
    }
}