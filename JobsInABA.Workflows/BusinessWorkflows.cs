using System.Collections.Generic;
using System.Linq;
using JobsInABA.BL;
using JobsInABA.DTOs;
using JobsInABA.Workflows.Models;
using JobsInABA.Workflows.Models.Assemblers;

namespace JobsInABA.Workflows
{
    public class BusinessWorkflows
    {
        BusinessBL _BusinessBL;
        AddressBL _AddressBL;
        EmailsBL _EmailsBL;
        PhonesBL _PhonesBL;
        
        public BussinessDataModel GetBusiness(int id)
        {
            BussinessDataModel bussinessDataModel = null;
            if (id > 0)
            {
                BusinessDTO BusinessDTO = businessBL.Get(id);

                if (BusinessDTO != null)
                {
                    bussinessDataModel = GetBusiness(BusinessDTO);
                }
            }
            return bussinessDataModel;
        }

        public BussinessDataModel GetBusiness(BusinessDTO businessDTO)
        {
            BussinessDataModel bussinessDataModel = null;
            if (businessDTO != null)
            {
                BusinessAddressDTO BusinessAddressDTO = (businessDTO.BusinessAddresses != null) ? businessDTO.BusinessAddresses.Where(o => o.IsPrimary).FirstOrDefault() : null;
                AddressDTO oPrimaryAddressDTO = (BusinessAddressDTO != null) ? BusinessAddressDTO.Address : null;

                BusinessPhoneDTO BusinessPhoneDTO = (businessDTO.BusinessPhones != null) ? businessDTO.BusinessPhones.Where(o => o.IsPrimary).FirstOrDefault() : null;
                PhoneDTO oPrimaryPhoneDTO = (BusinessPhoneDTO != null) ? BusinessPhoneDTO.Phone : null;

                BusinessEmailDTO BusinessEmailDTO = (businessDTO.BusinessEmails != null) ? businessDTO.BusinessEmails.Where(o => o.IsPrimary).FirstOrDefault() : null;
                EmailDTO oPrimaryEmailDTO = (BusinessEmailDTO != null) ? BusinessEmailDTO.Email : null;

                bussinessDataModel = BussinessDataModelAssembler.ToDataModel(businessDTO, oPrimaryAddressDTO, oPrimaryPhoneDTO, oPrimaryEmailDTO);
                bussinessDataModel.BusinessAddressID = (BusinessAddressDTO != null) ? BusinessAddressDTO.BusinessAddressID : 0;
                bussinessDataModel.BusinessPhoneID = (BusinessPhoneDTO != null) ? BusinessPhoneDTO.BusinessPhoneID : 0;
                bussinessDataModel.BusinessEmailID = (BusinessEmailDTO != null) ? BusinessEmailDTO.BusinessEmailID : 0;
            }
            return bussinessDataModel;
        }

        public List<BussinessDataModel> GetBusinesss()
        {
            List<BussinessDataModel> BusinessDataModels = new List<BussinessDataModel>();

            List<BusinessDTO> BusinessDTOs = businessBL.Get();

            BusinessDataModels = BusinessDTOs.Select(Businessdto => GetBusiness(Businessdto)).ToList();

            return BusinessDataModels;
        }

        public BussinessDataModel CreateBusiness(BussinessDataModel businessDataModel)
        {
            if (businessDataModel != null)
            {
                BusinessDTO businessDTO = new BusinessDTO();
                AddressDTO addressDTO = new AddressDTO();
                PhoneDTO phoneDTO = new PhoneDTO();
                EmailDTO emailDTO = new EmailDTO();
                
                businessDTO = BussinessDataModelAssembler.ToBusinessDTO(businessDataModel);
                phoneDTO = BussinessDataModelAssembler.ToPhoneDTO(businessDataModel);
                emailDTO = BussinessDataModelAssembler.ToEmailDTO(businessDataModel);
                addressDTO = BussinessDataModelAssembler.ToAddressDTO(businessDataModel);

                if (businessDTO != null)
                {
                    businessDTO = businessBL.Create(businessDTO);
                }
                if (phoneDTO != null)
                {
                    phoneDTO = phonesBL.Create(phoneDTO);
                }
                if (emailDTO != null)
                {
                    emailsBL.Create(emailDTO);
                }
                if (addressDTO != null)
                {
                    addressBL.Create(addressDTO);
                }
            }

            return businessDataModel;
        }

        public BussinessDataModel UpdateBusiness(BussinessDataModel businessDataModel)
        {
            if (businessDataModel != null)
            {
                BusinessDTO businessDTO = new BusinessDTO();
                AddressDTO addressDTO = new AddressDTO();
                PhoneDTO phoneDTO = new PhoneDTO();
                EmailDTO emailDTO = new EmailDTO();

                businessDTO = BussinessDataModelAssembler.ToBusinessDTO(businessDataModel);
                phoneDTO = BussinessDataModelAssembler.ToPhoneDTO(businessDataModel);
                emailDTO = BussinessDataModelAssembler.ToEmailDTO(businessDataModel);
                addressDTO = BussinessDataModelAssembler.ToAddressDTO(businessDataModel);

                if (businessDTO != null)
                {
                    businessDTO = businessBL.Update(businessDTO);
                }
                if (phoneDTO != null)
                {
                    phoneDTO = phonesBL.Update(phoneDTO);
                }
                if (emailDTO != null)
                {
                    emailDTO = emailsBL.Update(emailDTO);
                }
                if (addressDTO != null)
                {
                    addressDTO = addressBL.Update(addressDTO);
                }
            }

            return businessDataModel;
        }

        public bool DeleteBusiness(int id)
        {
            return businessBL.Delete(id);
        }

        private BusinessBL businessBL
        {
            get
            {
                if (_BusinessBL == null) _BusinessBL = new BusinessBL();
                return _BusinessBL;
            }
        }

        private AddressBL addressBL
        {
            get
            {
                if (_AddressBL == null) _AddressBL = new AddressBL();
                return _AddressBL;
            }
        }

        private EmailsBL emailsBL
        {
            get
            {
                if (_EmailsBL == null) _EmailsBL = new EmailsBL();
                return _EmailsBL;
            }
        }

        private PhonesBL phonesBL
        {
            get
            {
                if (_PhonesBL == null) _PhonesBL = new PhonesBL();
                return _PhonesBL;
            }
        }
    }
}
