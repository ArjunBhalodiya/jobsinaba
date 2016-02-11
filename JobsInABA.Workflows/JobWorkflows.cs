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

namespace JobsInABA.Workflows
{
    public class JobWorkflows
    {
        JobBL _JobsBL;
        AddressBL _AddressBL;
        EmailsBL _EmailsBL;
        PhonesBL _PhonesBL;
        AddressWorkflows _AddressWorkflows;

        public JobDataModel GetJob(int id)
        {

            JobDataModel oJobDataModel = null;
            if (id > 0)
            {
                JobDTO oJobDTO = oJobsBL.Get(id);

                if (oJobDTO != null)
                {
                    oJobDataModel = GetJob(oJobDTO);
                }
            }

            return oJobDataModel;
        }

        public JobDataModel GetJob(JobDTO oJobDTO)
        {

            JobDataModel oJobDataModel = null;
            if (oJobDTO != null)
            {

                JobAddressDTO oJobAddressDTO = (oJobDTO.JobAddresses != null) ? oJobDTO.JobAddresses.Where(o => o.IsPrimary).FirstOrDefault() : null;
                AddressDTO oPrimaryAddressDTO = (oJobAddressDTO != null) ? oJobAddressDTO.Address : null; //oAddressBL.Get(oJobAddressDTO.AddressID) : null;

                JobPhoneDTO oJobPhoneDTO = (oJobDTO.JobPhones != null) ? oJobDTO.JobPhones.Where(o => o.IsPrimary).FirstOrDefault() : null;
                PhoneDTO oPrimaryPhoneDTO = (oJobPhoneDTO != null) ? oJobPhoneDTO.Phone : null; //oPhonesBL.Get(oJobPhoneDTO.PhoneID) : null;

                JobEmailDTO oJobEmailDTO = (oJobDTO.JobEmails != null) ? oJobDTO.JobEmails.Where(o => o.IsPrimary).FirstOrDefault() : null;
                EmailDTO oPrimaryEmailDTO = (oJobEmailDTO != null) ? oJobEmailDTO.Email : null; //oEmailsBL.Get(oJobEmailDTO.EmailID) : null;

                oJobDataModel = JobDataModelAssembler.ToDataModel(oJobDTO, oPrimaryAddressDTO, oPrimaryPhoneDTO, oPrimaryEmailDTO);
                oJobDataModel.PrimaryJobAddressID = (oJobAddressDTO != null) ? oJobAddressDTO.JobAddressID : 0;
                oJobDataModel.PrimaryJobPhoneID = (oJobPhoneDTO != null) ? oJobPhoneDTO.JobPhoneID : 0;
                oJobDataModel.PrimaryJobEmailID = (oJobEmailDTO != null) ? oJobEmailDTO.JobEmailID : 0;

                //Get All the Addresses.
                oJobDataModel.Addresses = (oJobDTO.JobAddresses != null) ? oAddressWorkflows.GetAddresses(oJobDTO.JobAddresses.Select(ua => ua.Address).ToList()) : null;
            }
            return oJobDataModel;
        }

        public List<JobDataModel> GetJobs()
        {

            List<JobDataModel> oJobDataModels = new List<JobDataModel>();

            List<JobDTO> oJobDTOs = oJobsBL.GetJobs();

            oJobDataModels = oJobDTOs.Select(Jobdto => GetJob(Jobdto)).ToList();

            return oJobDataModels;
        }

        public JobDataModel CreateJob(JobDataModel oJobDataModel)
        {

            if (oJobDataModel != null)
            {
                JobDTO oJobDTO = new JobDTO();
                PhoneDTO oPhoneDTO = new PhoneDTO();
                EmailDTO oEmailDTO = new EmailDTO();
                AddressDTO oAddressDTO = new AddressDTO();

                oJobDTO = JobDataModelAssembler.ToJobDTO(oJobDataModel);
                oPhoneDTO = JobDataModelAssembler.ToPhoneDTO(oJobDataModel);
                oEmailDTO = JobDataModelAssembler.ToEmailDTO(oJobDataModel);
                oAddressDTO = JobDataModelAssembler.ToAddressDTO(oJobDataModel);

                if (oJobDTO != null)
                {
                    oJobDTO = oJobsBL.Create(oJobDTO);
                }
                if (oPhoneDTO != null)
                {
                    oPhoneDTO = oPhonesBL.Create(oPhoneDTO);
                }
                if (oEmailDTO != null)
                {
                    oEmailsBL.Create(oEmailDTO);
                }
                if (oAddressDTO != null)
                {
                    oAddressBL.Create(oAddressDTO);
                }
            }

            return oJobDataModel;
        }

        private JobsBL oJobsBL
        {
            get
            {
                if (_JobsBL == null) _JobsBL = new JobsBL();
                return _JobsBL;
            }
        }

        private AddressBL oAddressBL
        {
            get
            {
                if (_AddressBL == null) _AddressBL = new AddressBL();
                return _AddressBL;
            }
        }

        private EmailsBL oEmailsBL
        {
            get
            {
                if (_EmailsBL == null) _EmailsBL = new EmailsBL();
                return _EmailsBL;
            }
        }

        private PhonesBL oPhonesBL
        {
            get
            {
                if (_PhonesBL == null) _PhonesBL = new PhonesBL();
                return _PhonesBL;
            }
        }

        private AddressWorkflows oAddressWorkflows
        {
            get
            {
                if (_AddressWorkflows == null) _AddressWorkflows = new AddressWorkflows();
                return _AddressWorkflows;
            }
        }
    }
}
