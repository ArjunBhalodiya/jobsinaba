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
    public class UserAccountRepo
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

        public UserAccount GetUserAccountByID(Int32 Id)
        {
            UserAccount oUserAccountAccount = null;

            using (DBContext)
            {
                try
                {
                    oUserAccountAccount = DBContext.UserAccounts.FirstOrDefault(o => o.UserAccountID == Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oUserAccountAccount;
        }

        public IEnumerable<UserAccount> GetUserAccount()
        {
            List<UserAccount> oUserAccounts = null;

            using (DBContext)
            {
                try
                {
                    var count = DBContext.Users.Count();
                    oUserAccounts = DBContext.UserAccounts.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oUserAccounts;
        }

        public UserAccount CreateUserAccount(UserAccount oUserAccount)
        {
            UserAccount oUserAccountReturn = null;

            using (DBContext)
            {
                try
                {
                    oUserAccountReturn = DBContext.UserAccounts.Add(oUserAccount);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return oUserAccountReturn;
        }

        public UserAccount UpdateUserAccount(UserAccount oUserAccount)
        {
            UserAccount oUserAccountReturn = null;
            if (oUserAccount != null && oUserAccount.UserAccountID > 0)
            {
                using (DBContext)
                {
                    UserAccount u = this.GetUserAccountByID(oUserAccount.UserAccountID);

                    if (u != null)
                    {
                        Mapper.Map<UserAccount, UserAccount>(oUserAccount, u);
                        DBContext.SaveChanges();
                        oUserAccountReturn = u;
                    }
                }
            }

            return oUserAccountReturn;
        }

        public bool DeleteUserAccount(int UserAccountID)
        {

            Boolean isDeleted = false;
            using (DBContext)
            {
                UserAccount u = this.GetUserAccountByID(UserAccountID);

                if (u != null)
                {
                    DBContext.UserAccounts.Remove(u);
                    DBContext.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }
    }
}
