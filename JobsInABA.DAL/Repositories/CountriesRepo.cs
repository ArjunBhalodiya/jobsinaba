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
    public class CountriesRepo
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Country> GetCountries()
        {
            return db.Countries;
        }

        public Country GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            return country;
        }

        public void UpdateCountry(int id, Country country)
        {
            db.Entry(country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Country CreateCountry(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();

            return country;
        }

        public Country DeleteCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return null;
            }

            db.Countries.Remove(country);
            db.SaveChanges();

            return country;
        }

        private bool CountryExists(int id)
        {
            return db.Countries.Count(e => e.CountryID == id) > 0;
        }
    }
}