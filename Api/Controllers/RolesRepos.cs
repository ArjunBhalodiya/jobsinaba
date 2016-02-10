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
    public class RolesRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Role> GetRoles()
        {
            return db.Roles;
        }

        public Role GetRole(int id)
        {
            Role role = db.Roles.Find(id);
            return role;
        }

        public void UpdateRole(int id, Role role)
        {
            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Role AddRole(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();

            return role;
        }

        public Role DeleteRole(int id)
        {
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return null;
            }

            db.Roles.Remove(role);
            db.SaveChanges();

            return role;
        }

        private bool RoleExists(int id)
        {
            return db.Roles.Count(e => e.RoleID == id) > 0;
        }
    }
}