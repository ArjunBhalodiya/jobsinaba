﻿using System;
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
    public class AddressesRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Address> GetAddresses()
        {
            return db.Addresses;
        }

        public Address GetAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return null;
            }

            return address;
        }

        public void PutAddress(int id, Address address)
        {
            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Address AddAddress(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();

            return address;
        }

        public Address DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return null;
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return address;
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.AddressID == id) > 0;
        }
    }
}