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
    public class JobBL
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

        public IEnumerable<JobDTO> Get()
        {
            IEnumerable<JobDTO> oJob = JobAssembler.ToDTOs(oJobRepos.GetJobs());

            return oJob;
        }

        public JobDTO Create(JobDTO oJob)
        {
            if (oJob != null)
            {
                return JobAssembler.ToDTO(oJobRepos.CreateJob(JobAssembler.ToEntity(oJob)));
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