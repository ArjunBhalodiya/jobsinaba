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
    public class UserAccountsRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<UserAccount> GetUserAccounts()
        {
            return db.UserAccounts;
        }

        public UserAccount GetUserAccount(int id)
        {
            UserAccount userAccount = db.UserAccounts.Find(id);
            return userAccount;
        }

        public void UpdateUserAccount(int id, UserAccount userAccount)
        {
            db.Entry(userAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public UserAccount AddUserAccount(UserAccount userAccount)
        {
            db.UserAccounts.Add(userAccount);
            db.SaveChanges();

            return userAccount;
        }

        public UserAccount DeleteUserAccount(int id)
        {
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return null;
            }

            db.UserAccounts.Remove(userAccount);
            db.SaveChanges();

            return userAccount;
        }

        public bool SignIn(string email, string password)
        {
            byte[] bytes = new byte[password.Length * sizeof(char)];
            System.Buffer.BlockCopy(password.ToCharArray(), 0, bytes, 0, bytes.Length);

            return (db.UserAccounts.Count(p => p.UserName == email && p.Password == bytes) > 0 ? true : false);
        }

        private bool UserAccountExists(int id)
        {
            return db.UserAccounts.Count(e => e.UserAccountID == id) > 0;
        }
    }
}