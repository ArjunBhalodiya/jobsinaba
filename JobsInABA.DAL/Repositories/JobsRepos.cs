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
    public class JobsRepos
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<Job> GetJobs()
        {
            return db.Jobs;
        }

        public Job GetJob(int id)
        {
            Job job = db.Jobs
                .Include(p => p.JobApplications.Select(x => x.JobApplicationStates).Select(y => y)).FirstOrDefault(i => i.JobID == id);
            return job;
        }

        public void UpdateJob(int id, Job job)
        {
            db.Entry(job).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Job CreateJob(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();

            return job;
        }

        public Job DeleteJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return null;
            }

            db.Jobs.Remove(job);
            db.SaveChanges();

            return job;
        }

        private bool JobExists(int id)
        {
            return db.Jobs.Count(e => e.JobID == id) > 0;
        }
    }
}