using JobsInABA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;

namespace JobsInABA.DAL.Repositories
{
    public class UserAddressesRepo
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<UserAddress> GetUserAddresses()
        {
            return db.UserAddresses;
        }

        public UserAddress GetUserAddress(int id)
        {
            UserAddress userAddress = db.UserAddresses.Find(id);
            return userAddress;
        }

        public void UpdateUserAddress(int id, UserAddress userAddress)
        {
            db.Entry(userAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public UserAddress CreateUserAddress(UserAddress userAddress)
        {
            db.UserAddresses.Add(userAddress);
            db.SaveChanges();

            return userAddress;
        }

        public UserAddress DeleteUserAddress(int id)
        {
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return null;
            }

            db.UserAddresses.Remove(userAddress);
            db.SaveChanges();

            return userAddress;
        }

        private bool UserAddressExists(int id)
        {
            return db.UserAddresses.Count(e => e.UserAddressID == id) > 0;
        }
    }
}