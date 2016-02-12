using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using JobsInABA.BL;
using JobsInABA.DTOs;
using JobsInABA.Workflows.Models;
using JobsInABA.Workflows.Models.Assemblers;
using JobsInABA.DAL.Repositories;

namespace JobsInABA.Workflows
{
    public class AddressWorkflows:AddressRepo
    {
        //AddressBL _AddressBL;
        //CountryBL _CountryBL;
        //EmailsBL _EmailsBL;
        //PhonesBL _PhonesBL;

        //public JobDataModel GetJob(int id)
        //{
        //    JobDataModel model = new JobDataModel();
        //    if (id > 0)
        //    {
        //        JobDTO oJobDTO = oJobsBL.Get(id);

        //        if (oJobDTO != null)
        //        {
        //            model = GetJob(oJobDTO);
        //        }
        //    }

        //    return model;
        //}

        //public JobDataModel GetJob(JobDTO oJobDTO)
        //{
        //    JobDataModel oJobDataModel = null;
        //    if (oJobDTO != null)
        //    {
        //        oJobDataModel = JobDataModelAssembler.ToDataModel(oJobsBL.Get(oJobDTO.JobID), null, null);
        //    }
        //    return oJobDataModel;
        //}

        //public List<JobDataModel> GetJobs()
        //{
        //    List<JobDataModel> oJobDataModels = new List<JobDataModel>();

        //    List<JobDTO> oJobDTOs = oJobsBL.Get().ToList();

        //    oJobDataModels = oJobDTOs.Select(Jobdto => GetJob(Jobdto)).ToList();

        //    return oJobDataModels;
        //}

        //public JobDataModel CreateJob(JobDataModel oJobDataModel)
        //{
        //    if (oJobDataModel != null)
        //    {
        //        JobDTO oJobDTO = new JobDTO();

        //        oJobDTO = JobDataModelAssembler.ToJobDTO(oJobDataModel);

        //        if (oJobDTO != null)
        //        {
        //            oJobDTO = oJobsBL.Create(oJobDTO);
        //        }
        //    }

        //    return oJobDataModel;
        //}

        //public JobDataModel UpdateJob(JobDataModel oJobDataModel)
        //{
        //    if (oJobDataModel != null)
        //    {
        //        JobDTO oJobDTO = new JobDTO();

        //        oJobDTO = JobDataModelAssembler.ToJobDTO(oJobDataModel);

        //        if (oJobDTO != null)
        //        {
        //            oJobDTO = oJobsBL.Update(oJobDTO);
        //        }
        //    }

        //    return oJobDataModel;
        //}

        //public bool DeleteJob(int id)
        //{
        //    return oJobsBL.Delete(id);
        //}

        //private JobBL oJobsBL
        //{
        //    get
        //    {
        //        if (_JobsBL == null) _JobsBL = new JobBL();
        //        return _JobsBL;
        //    }
        //}

        //private AddressBL oAddressBL
        //{
        //    get
        //    {
        //        if (_AddressBL == null) _AddressBL = new AddressBL();
        //        return _AddressBL;
        //    }
        //}

        //private EmailsBL oEmailsBL
        //{
        //    get
        //    {
        //        if (_EmailsBL == null) _EmailsBL = new EmailsBL();
        //        return _EmailsBL;
        //    }
        //}

        //private PhonesBL oPhonesBL
        //{
        //    get
        //    {
        //        if (_PhonesBL == null) _PhonesBL = new PhonesBL();
        //        return _PhonesBL;
        //    }
        //}

        //private AddressWorkflows oAddressWorkflows
        //{
        //    get
        //    {
        //        if (_AddressWorkflows == null) _AddressWorkflows = new AddressWorkflows();
        //        return _AddressWorkflows;
        //    }
        //}
    }
}
