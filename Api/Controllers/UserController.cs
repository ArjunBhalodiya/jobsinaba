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

namespace Api.Controllers
{
    public class UserController : ApiController
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        }

        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            return user;
        }

        public void UpdateUser(int id, User user)
        {
            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public User AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        public User DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return null;
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return user;
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}