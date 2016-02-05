using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsInABA.DAL.Entities;
using AutoMapper;

namespace JobsInABA.DAL.Repositories
{
    public class AddressRepo
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

        public Address GetAddressByID(Int32 Id)
        {
            Address oAddress = null;

            using (DBContext)
            {
                try
                {
                    oAddress = DBContext.Addresses.Where<Address>(o => o.AddressID == Id)
                                //.Include(o => o.Phones)
                                .Include(o => o.Country)
                                .Include(o => o.TypeCode)
                                .Include(o => o.TypeCode.ClassType)
                                .FirstOrDefault<Address>();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oAddress;
        }

        public IEnumerable<Address> GetAddress()
        {
            List<Address> oAddress = null;

            using (DBContext)
            {
                try
                {
                    oAddress = DBContext.Addresses.ToList();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oAddress;
        }

        public Address CreateAddress(Address oAddress)
        {
            Address oAddressReturn = null;

            using (DBContext)
            {
                try
                {
                    oAddressReturn = DBContext.Addresses.Add(oAddress);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oAddressReturn;
        }

        public Address UpdateAddress(Address oAddress)
        {
            Address oAddressReturn = null;
            if (oAddress != null && oAddress.AddressID > 0)
            {
                using (DBContext)
                {
                    Address u = this.GetAddressByID(oAddress.AddressID);

                    if (u != null)
                    {
                        Mapper.Map<Address, Address>(oAddress, u);
                        DBContext.SaveChanges();
                        oAddressReturn = u;
                    }
                }
            }

            return oAddressReturn;
        }

        public bool DeleteAddress(int AddressID)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                Address u = this.GetAddressByID(AddressID);

                if (u != null)
                {
                    DBContext.Addresses.Remove(u);
                    DBContext.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }
    }
}
