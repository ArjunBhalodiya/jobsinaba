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
    class JobApplicationStateBL
    {
        JobApplicationStatesRepo _JobApplicationStateRepos;

        private JobApplicationStatesRepo oJobApplicationStateRepos
        {
            get
            {
                if (_JobApplicationStateRepos == null) _JobApplicationStateRepos = new JobApplicationStatesRepo();
                return _JobApplicationStateRepos;
            }
        }

        public JobApplicationStateDTO Get(int JobApplicationStateID)
        {
            JobApplicationStateDTO oJobApplicationStateDTO = null;
            if (JobApplicationStateID > 0)
            {
                JobApplicationState oJobApplicationState = oJobApplicationStateRepos.GetJobApplicationState(JobApplicationStateID);
            }

            return oJobApplicationStateDTO;
        }

        public JobApplicationState Create(JobApplicationState oJobApplicationState)
        {
            if (oJobApplicationState != null)
            {
                return oJobApplicationStateRepos.CreateJobApplicationState(oJobApplicationState);
            }

            return null;
        }

        public JobApplicationStateDTO Update(JobApplicationStateDTO oJobApplicationStateDTO)
        {
            JobApplicationStateDTO returnUserMap = null;
            if (oJobApplicationStateDTO != null && oJobApplicationStateDTO.JobApplicationStateID > 0)
            {
                oJobApplicationStateRepos.UpdateJobApplicationState(0, JobApplicationStateAssembler.ToEntity(oJobApplicationStateDTO));
                returnUserMap = oJobApplicationStateDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int JobApplicationStateID)
        {
            Boolean isDeleted = false;

            if (JobApplicationStateID > 0)
            {
                try
                {
                    oJobApplicationStateRepos.DeleteJobApplicationState(JobApplicationStateID);
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