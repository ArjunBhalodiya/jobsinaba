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
    public class JobApplicationStatesRepo
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<JobApplicationState> GetJobApplicationStates()
        {
            return db.JobApplicationStates;
        }

        public JobApplicationState GetJobApplicationState(int id)
        {
            JobApplicationState jobApplicationState = db.JobApplicationStates.Find(id);
            return jobApplicationState;
        }

        public void UpdateJobApplicationState(int id, JobApplicationState jobApplicationState)
        {
            db.Entry(jobApplicationState).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public JobApplicationState AddJobApplicationState(JobApplicationState jobApplicationState)
        {
            db.JobApplicationStates.Add(jobApplicationState);
            db.SaveChanges();

            return jobApplicationState;
        }

        public JobApplicationState DeleteJobApplicationState(int id)
        {
            JobApplicationState jobApplicationState = db.JobApplicationStates.Find(id);
            if (jobApplicationState == null)
            {
                return null;
            }

            db.JobApplicationStates.Remove(jobApplicationState);
            db.SaveChanges();

            return jobApplicationState;
        }

        private bool JobApplicationStateExists(int id)
        {
            return db.JobApplicationStates.Count(e => e.JobApplicationStateID == id) > 0;
        }
    }
}