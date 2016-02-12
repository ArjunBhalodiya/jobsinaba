using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsInABA.BL;
using JobsInABA.DTOs;

namespace JobsInABA.Workflows.Models.Assemblers
{
    public static class BussinessDataModelAssembler
    {
        public static BussinessDataModel ToDataModel(BusinessDTO bussinessDTO, AddressDTO primaryAddressDTO, PhoneDTO primaryPhoneDTO, EmailDTO primaryEmailDTO)
        {
            BussinessDataModel model = null;

            if (model != null)
            {
                model = new BussinessDataModel();
                model.Abbreviation = bussinessDTO.Abbreviation;
                model.BusinessID = bussinessDTO.BusinessID;
                model.BusinessTypeID = bussinessDTO.BusinessTypeID;
                model.insdt = bussinessDTO.insdt;
                model.insuser = bussinessDTO.insuser;
                model.IsActive = bussinessDTO.IsActive;
                model.IsDeleted = bussinessDTO.IsDeleted;
                model.Name = bussinessDTO.Name;
                model.StartDate = bussinessDTO.StartDate;
                model.upddt = bussinessDTO.upddt;
                model.upduser = bussinessDTO.upduser;
            }

            if (primaryAddressDTO != null)
            {
                model.BusinessAddressAddressTypeID = primaryAddressDTO.AddressTypeID;
                model.BusinessAddressCity = primaryAddressDTO.City;
                model.BusinessAddressCountryID = primaryAddressDTO.CountryID;
                model.BusinessAddressID = primaryAddressDTO.AddressID;
                model.BusinessAddressLine1 = primaryAddressDTO.Line1;
                model.BusinessAddressLine2 = primaryAddressDTO.Line2;
                model.BusinessAddressLine3 = primaryAddressDTO.Line3;
                model.BusinessAddressState = primaryAddressDTO.State;

                model.BusinessAddressTitle = primaryAddressDTO.Title;
                model.BusinessAddressZipCode = primaryAddressDTO.ZipCode;
            }

            if (primaryPhoneDTO != null)
            {
                model.BusinessPhoneCountryID = primaryPhoneDTO.CountryID;
                model.BusinessPhoneExt = primaryPhoneDTO.Ext;
                model.BusinessPhoneID = primaryPhoneDTO.PhoneID;
                model.BusinessPhoneNumber = primaryPhoneDTO.Number;
                model.BusinessPhoneTypeID = primaryPhoneDTO.PhoneTypeID;
            }

            if (primaryEmailDTO != null)
            {
                model.BusinessEmailAddress = primaryEmailDTO.Address;
                model.BusinessEmailID = primaryEmailDTO.EmailID;
                model.BusinessEmailTypeID = primaryEmailDTO.EmailTypeID;
            }


            return model;
        }

        public static BusinessDTO ToBusinessDTO(BussinessDataModel datamodel)
        {

            BusinessDTO dto = new BusinessDTO();
            if (datamodel != null)
            {
                dto.Abbreviation = datamodel.Abbreviation;
                dto.BusinessID = datamodel.BusinessID;
                dto.BusinessTypeID = datamodel.BusinessTypeID;
                dto.insdt = datamodel.insdt;
                dto.insuser = datamodel.insuser;
                dto.IsActive = datamodel.IsActive;
                dto.IsDeleted = datamodel.IsDeleted;
                dto.Name = datamodel.Name;
                dto.StartDate = datamodel.StartDate;
                dto.upddt = datamodel.upddt;
                dto.upduser = datamodel.upduser;
            }

            return dto;
        }

        public static AddressDTO ToAddressDTO(BussinessDataModel model)
        {

            AddressDTO dto = new AddressDTO();
            if (model != null)
            {
                dto.AddressTypeID = model.BusinessAddressAddressTypeID;
                dto.City = model.BusinessAddressCity;
                dto.CountryID = model.BusinessAddressCountryID;
                dto.AddressID = model.BusinessAddressID;
                dto.Line1 = model.BusinessAddressLine1;
                dto.Line2 = model.BusinessAddressLine2;
                dto.Line3 = model.BusinessAddressLine3;
                dto.State = model.BusinessAddressState;

                dto.Title = model.BusinessAddressTitle;
                dto.ZipCode = model.BusinessAddressZipCode;
            }

            return dto;
        }

        public static PhoneDTO ToPhoneDTO(BussinessDataModel model)
        {

            PhoneDTO dto = new PhoneDTO();
            if (model != null)
            {
                dto.CountryID = model.BusinessPhoneCountryID;
                dto.Ext = model.BusinessPhoneExt;
                dto.PhoneID = model.BusinessPhoneID;
                dto.Number = model.BusinessPhoneNumber;
                dto.PhoneTypeID = model.BusinessPhoneTypeID;
            }

            return dto;
        }

        public static EmailDTO ToEmailDTO(BussinessDataModel model)
        {
            EmailDTO dto = new EmailDTO();
            if (model != null)
            {
                dto.Address = model.BusinessEmailAddress;
                dto.EmailID = model.BusinessEmailID;
                dto.EmailTypeID = model.BusinessEmailTypeID;
            }

            return dto;
        }
    }
}
