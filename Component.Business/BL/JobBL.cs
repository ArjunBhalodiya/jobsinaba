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
    class JobBL
    {
        JobsRepos _JobRepos;

        private JobsRepos oJobRepos
        {
            get
            {
                if (_JobRepos == null) _JobRepos = new JobsRepos();
                return _JobRepos;
            }
        }

        public JobDTO Get(int JobID)
        {
            JobDTO oJobDTO = null;
            if (JobID > 0)
            {
                Job oJob = oJobRepos.GetJob(JobID);
            }

            return oJobDTO;
        }

        public Job Create(Job oJob)
        {
            if (oJob != null)
            {
                return oJobRepos.CreateJob(oJob);
            }

            return null;
        }

        public JobDTO Update(JobDTO oJobDTO)
        {
            JobDTO returnUserMap = null;
            if (oJobDTO != null && oJobDTO.JobID > 0)
            {
                oJobRepos.UpdateJob(0, JobAssembler.ToEntity(oJobDTO));
                returnUserMap = oJobDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int JobID)
        {
            Boolean isDeleted = false;

            if (JobID > 0)
            {
                try
                {
                    oJobRepos.DeleteJob(JobID);
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