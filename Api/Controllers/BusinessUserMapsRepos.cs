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
    public class BusinessUserMapsRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<BusinessUserMap> GetBusinessUserMaps()
        {
            return db.BusinessUserMaps;
        }

        public BusinessUserMap GetBusinessUserMap(int id)
        {
            BusinessUserMap businessUserMap = db.BusinessUserMaps.Find(id);
            return businessUserMap;
        }

        public void PutBusinessUserMap(int id, BusinessUserMap businessUserMap)
        {
            db.Entry(businessUserMap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public BusinessUserMap PostBusinessUserMap(BusinessUserMap businessUserMap)
        {
            db.BusinessUserMaps.Add(businessUserMap);
            db.SaveChanges();

            return businessUserMap;
        }

        public BusinessUserMap DeleteBusinessUserMap(int id)
        {
            BusinessUserMap businessUserMap = db.BusinessUserMaps.Find(id);
            if (businessUserMap == null)
            {
                return null;
            }

            db.BusinessUserMaps.Remove(businessUserMap);
            db.SaveChanges();

            return businessUserMap;
        }

        private bool BusinessUserMapExists(int id)
        {
            return db.BusinessUserMaps.Count(e => e.BusinessUserMapID == id) > 0;
        }
    }
}