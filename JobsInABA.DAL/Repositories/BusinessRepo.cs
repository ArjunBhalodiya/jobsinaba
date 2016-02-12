using System;
using System.Collections.Generic;
using System.Linq;
using JobsInABA.DAL.Entities;
using AutoMapper;

namespace JobsInABA.DAL.Repositories
{
    public class BusinessRepo
    {
        JobsInABAEntities _DBContext;
        private JobsInABAEntities DBContext
        {
            get
            {
                if (_DBContext == null) _DBContext = new JobsInABAEntities();

                return _DBContext;
            }
        }

        public Business GetBusinessByID(Int32 Id)
        {
            Business oBusiness = null;

            using (DBContext)
            {
                try
                {
                    oBusiness = DBContext.Businesses.First<Business>(o => o.BusinessID == Id);
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oBusiness;
        }

        public IEnumerable<Business> GetBusinesss()
        {
            List<Business> oBusinesss = null;

            using (DBContext)
            {
                try
                {
                    oBusinesss = DBContext.Businesses.ToList();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oBusinesss;
        }

        public Business CreateBusiness(Business oBusiness)
        {
            Business oBusinessReturn = null;

            using (DBContext)
            {
                try
                {
                    oBusinessReturn = DBContext.Businesses.Add(oBusiness);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oBusinessReturn;
        }

        public Business UpdateBusiness(Business oBusiness)
        {
            Business oBusinessReturn = null;
            if (oBusiness != null && oBusiness.BusinessID > 0)
            {
                using (DBContext)
                {
                    Business u = this.GetBusinessByID(oBusiness.BusinessID);

                    if (u != null)
                    {
                        Mapper.Map<Business, Business>(oBusiness, u);
                        DBContext.SaveChanges();
                        oBusinessReturn = u;
                    }
                }
            }

            return oBusinessReturn;
        }

        public bool DeleteBusiness(int BusinessID)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                Business u = this.GetBusinessByID(BusinessID);

                if (u != null)
                {
                    DBContext.Businesses.Remove(u);
                    DBContext.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }
    }
}
