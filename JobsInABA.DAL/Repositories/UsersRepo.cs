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
    public class UsersRepo
    {
        JobsInABAEntities _DBContext;
        private JobsInABAEntities DBContext {
            get { 
                if (_DBContext == null) _DBContext = new JobsInABAEntities();

                return _DBContext;
            }
        }

        public User GetUserByID(Int32 Id) {
            User oUser = null;
            
            using (DBContext) {
                try {
                    oUser = DBContext.Users
                            .Include(o => o.UserAddresses
                                            .Select(ua => ua.Address)
                                            .Select(ad => ad.TypeCode)
                                            .Select(typ => typ.ClassType)
                            )
                            .Include(o => o.UserAddresses
                                            .Select(ua => ua.Address)
                                            .Select(ad => ad.Country)
                            )
                            .Include (o => o.UserEmails
                                            .Select(ue => ue.Email)
                                            .Select(e => e.TypeCode)
                                            .Select(typ => typ.ClassType)
                            )
                            .Include (o => o.UserPhones
                                            .Select(up => up.Phone)
                                            .Select(p => p.TypeCode)
                                            .Select(typ => typ.ClassType)
                            )
                            .FirstOrDefault(o => o.UserID == Id);
                }
                catch (Exception ex) { 
                    //Log Exception.
                }
            }

            return oUser;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> oUsers = null;

            using (DBContext) {
                try {
                    oUsers = DBContext.Users
                                .Include(o => o.UserAddresses
                                            .Select(ua => ua.Address)
                                            .Select(ad => ad.TypeCode)
                                            .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.UserAddresses
                                                .Select(ua => ua.Address)
                                                .Select(ad => ad.Country)
                                )
                                .Include(o => o.UserEmails
                                                .Select(ue => ue.Email)
                                                .Select(e => e.TypeCode)
                                                .Select(typ => typ.ClassType)
                                )
                                .Include(o => o.UserPhones
                                                .Select(up => up.Phone)
                                                .Select(p => p.TypeCode)
                                                .Select(typ => typ.ClassType)
                                )
                                .ToList();
                }
                catch (Exception ex)
                {
                    //Log Exception.
                }
            }

            return oUsers;
        }

        public User CreateUser(User oUser) {
            User oUserReturn = null;

            using (DBContext)
            {
                try {
                    oUserReturn = DBContext.Users.Add(oUser);
                    DBContext.SaveChanges();
                }
                catch (Exception ex) {
                    //Log Exception.
                }
            }

            return oUserReturn;
        }

        public User UpdateUser(User oUser)
        {
            User oUserReturn = null;
            if (oUser != null && oUser.UserID > 0)
            {
                using (DBContext)
                {
                    User u = this.GetUserByID(oUser.UserID);

                    if (u != null)
                    {
                        Mapper.Map<User, User>(oUser, u);
                        DBContext.SaveChanges();
                        oUserReturn = u;
                    }
                }
            }

            return oUserReturn;
        }

        public bool DeleteUser(int UserID) {

            Boolean isDeleted = false;
            using (DBContext)
            {
                User u = this.GetUserByID(UserID);

                if (u != null)
                {
                    DBContext.Users.Remove(u);
                    DBContext.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }
    }
}
