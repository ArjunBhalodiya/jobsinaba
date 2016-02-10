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
    public class JobApplicationsRepo
    {
        private JobsInABAEntities db = new JobsInABAEntities();

        public IEnumerable<JobApplication> GetJobApplications()
        {
            return db.JobApplications;
        }

        public JobApplication GetJobApplication(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            return jobApplication;
        }

        public void UpdateJobApplication(int id, JobApplication jobApplication)
        {
            db.Entry(jobApplication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public JobApplication CreateJobApplication(JobApplication jobApplication)
        {
            db.JobApplications.Add(jobApplication);
            db.SaveChanges();

            return jobApplication;
        }

        public JobApplication DeleteJobApplication(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return null;
            }

            db.JobApplications.Remove(jobApplication);
            db.SaveChanges();

            return jobApplication;
        }

        private bool JobApplicationExists(int id)
        {
            return db.JobApplications.Count(e => e.JobApplicationID == id) > 0;
        }
    }
}