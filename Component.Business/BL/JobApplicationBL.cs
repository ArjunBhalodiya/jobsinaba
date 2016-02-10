using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using JobsInABA.DTOs;
using JobsInABA.DTOs.Assemblers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsInABA.BL
{
    class JobApplicationApplicationBL
    {
        JobApplicationsRepo _JobApplicationRepos;

        private JobApplicationsRepo oJobApplicationRepos
        {
            get
            {
                if (_JobApplicationRepos == null) _JobApplicationRepos = new JobApplicationsRepo();
                return _JobApplicationRepos;
            }
        }

        public JobApplicationDTO Get(int JobApplicationID)
        {
            JobApplicationDTO oJobApplicationDTO = null;
            if (JobApplicationID > 0)
            {
                JobApplication oJobApplication = oJobApplicationRepos.GetJobApplication(JobApplicationID);
            }

            return oJobApplicationDTO;
        }

        public JobApplication Create(JobApplication oJobApplication)
        {
            if (oJobApplication != null)
            {
                return oJobApplicationRepos.CreateJobApplication(oJobApplication);
            }

            return null;
        }

        public JobApplicationDTO Update(JobApplicationDTO oJobApplicationDTO)
        {
            JobApplicationDTO returnUserMap = null;
            if (oJobApplicationDTO != null && oJobApplicationDTO.JobApplicationID > 0)
            {
                oJobApplicationRepos.UpdateJobApplication(0, JobApplicationAssembler.ToEntity(oJobApplicationDTO));
                returnUserMap = oJobApplicationDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int JobApplicationID)
        {
            Boolean isDeleted = false;

            if (JobApplicationID > 0)
            {
                try
                {
                    oJobApplicationRepos.DeleteJobApplication(JobApplicationID);
                }
                catch
                {
                    return false;
                }
            }
            return isDeleted;
        }
    }
}