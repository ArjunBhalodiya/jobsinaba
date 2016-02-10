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
                model = new BussinessDataModel
                {
                    Abbreviation = bussinessDTO.Abbreviation,
                    BusinessID = bussinessDTO.BusinessID,
                    BusinessTypeID = bussinessDTO.BusinessTypeID,
                    insdt = bussinessDTO.insdt,
                    insuser = bussinessDTO.insuser,
                    IsActive = bussinessDTO.IsActive,
                    IsDeleted = bussinessDTO.IsDeleted,
                    Name = bussinessDTO.Name,
                    StartDate = bussinessDTO.StartDate,
                    upddt = bussinessDTO.upddt,
                    upduser = bussinessDTO.upduser
                };

                if (primaryAddressDTO != null)
                {
                    model.BusinessPrimaryAddressID = primaryAddressDTO.AddressID;
                    model.BussinessAddressTypeID = primaryAddressDTO.AddressTypeID;
                    model.BussinessAddressCity = primaryAddressDTO.City;
                    model.BussinessCountryAbbreviation = primaryAddressDTO.Country.Abbreviation;
                    model.BussinessCountryCode = primaryAddressDTO.Country.Code;
                    model.BussinessCountryName = primaryAddressDTO.Country.Name;
                    model.BussinessCountryPhoneCode = primaryAddressDTO.Country.PhoneCode;
                    model.BussinessAddressCountryID = primaryAddressDTO.CountryID;

                    model.BussinessAddressLine1 = primaryAddressDTO.Line1;
                    model.BussinessAddressLine2 = primaryAddressDTO.Line2;
                    model.BussinessAddressLine3 = primaryAddressDTO.Line3;
                    model.BussinessAddressTitle = primaryAddressDTO.Title;
                    model.BussinessAddressState = primaryAddressDTO.State;
                    model.BussinessAddressTypeName = primaryAddressDTO.TypeCode.Name;
                    model.BussinessAddressTypeCode = primaryAddressDTO.TypeCode.Code;
                    model.BussinessAddressTypeDescription = primaryAddressDTO.TypeCode.Description;
                    model.BussinessAddressTypeClassTypeID = primaryAddressDTO.TypeCode.ClassTypeID;
                    model.BussinessAddressTypeParentTypeCodeID = primaryAddressDTO.TypeCode.TypeCodeID;

                    model.BussinessAddressCity = primaryAddressDTO.City;
                    model.BussinessAddressState = primaryAddressDTO.State;
                    model.BussinessAddressZipCode = primaryAddressDTO.ZipCode;
                    model.BussinessAddressCountryID = primaryAddressDTO.CountryID;
                }

                if (primaryPhoneDTO != null)
                {
                    model.BusinessPhoneID = primaryPhoneDTO.PhoneID;
                    model.BussinessPhoneCountryID = primaryPhoneDTO.CountryID;
                    model.BussinessPhoneNumber = primaryPhoneDTO.Number;
                    model.BussinessPhoneNumberExt = primaryPhoneDTO.Ext;
                    model.BussinessPhoneTypeID = primaryPhoneDTO.PhoneTypeID;

                    model.BussinessPhoneTypeName = primaryPhoneDTO.TypeCode.Name;
                    model.BussinessPhoneTypeCode = primaryPhoneDTO.TypeCode.Code;
                    model.BussinessPhoneTypeDescription = primaryPhoneDTO.TypeCode.Description;
                    model.BussinessPhoneTypeClassTypeID = primaryPhoneDTO.TypeCode.ClassTypeID;
                    model.BussinessPhoneTypeParentTypeCodeID = primaryPhoneDTO.TypeCode.ClassTypeID;
                }

                if (primaryEmailDTO != null)
                {
                    model.BusinessPrimaryEmailID = primaryEmailDTO.EmailID;
                    model.BussinessEmailAddress = primaryEmailDTO.Address;
                    model.BussinessEmailTypeID = primaryEmailDTO.EmailTypeID;
                    model.BussinessEmailTypeName = primaryEmailDTO.TypeCode.Name;
                    model.BussinessEmailTypeCode = primaryEmailDTO.TypeCode.Code;
                    model.BussinessEmailTypeDescription = primaryEmailDTO.TypeCode.Description;
                    model.BussinessEmailTypeClassTypeID = primaryEmailDTO.TypeCode.ClassTypeID;
                    model.BussinessEmailTypeParentTypeCodeID = primaryEmailDTO.TypeCode.ParentTypeCodeID;
                }
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
                dto.AddressID = model.BusinessPrimaryAddressID;
                dto.AddressTypeID = model.BussinessAddressTypeID;
                dto.City = model.BussinessAddressCity;

                dto.Country.Abbreviation = model.BussinessCountryAbbreviation;
                dto.Country.Code = model.BussinessCountryCode;
                dto.Country.Name = model.BussinessCountryName;
                dto.Country.PhoneCode = model.BussinessCountryPhoneCode;
                dto.CountryID = model.BussinessAddressCountryID;

                dto.Line1 = model.BussinessAddressLine1;
                dto.Line2 = model.BussinessAddressLine2;
                dto.Line3 = model.BussinessAddressLine3;
                dto.Title = model.BussinessAddressTitle;
                dto.State = model.BussinessAddressState;
                dto.TypeCode.Name = model.BussinessAddressTypeName;
                dto.TypeCode.Code = model.BussinessAddressTypeCode;
                dto.TypeCode.Description = model.BussinessAddressTypeDescription;
                dto.TypeCode.ClassTypeID = model.BussinessAddressTypeClassTypeID;
                dto.TypeCode.ParentTypeCodeID = model.BussinessAddressTypeParentTypeCodeID;

                dto.City = model.BussinessAddressCity;
                dto.State = model.BussinessAddressState;
                dto.ZipCode = model.BussinessAddressZipCode;
                dto.CountryID = model.BussinessAddressCountryID;
            }

            return dto;
        }

        public static PhoneDTO ToPhoneDTO(BussinessDataModel model)
        {

            PhoneDTO dto = new PhoneDTO();
            if (model != null)
            {
                dto.CountryID = model.BussinessPhoneCountryID;
                dto.Number = model.BussinessPhoneNumber;
                dto.Ext = model.BussinessPhoneNumberExt;
                dto.PhoneTypeID = model.BussinessPhoneTypeID;

                dto.TypeCode.Name = model.BussinessPhoneTypeName;
                dto.TypeCode.Code = model.BussinessPhoneTypeCode;
                dto.TypeCode.Description = model.BussinessPhoneTypeDescription;
                dto.TypeCode.ClassTypeID = model.BussinessPhoneTypeClassTypeID;
                dto.TypeCode.ParentTypeCodeID = model.BussinessPhoneTypeParentTypeCodeID;
            }

            return dto;
        }

        public static EmailDTO ToEmailDTO(BussinessDataModel model)
        {
            EmailDTO dto = new EmailDTO();
            if (model != null)
            {
                dto.Address = model.BussinessEmailAddress;
                dto.EmailTypeID = model.BussinessEmailTypeID;
                dto.TypeCode.Name = model.BussinessEmailTypeName;
                dto.TypeCode.Code = model.BussinessEmailTypeCode;
                dto.TypeCode.Description = model.BussinessEmailTypeDescription;
                dto.TypeCode.ClassTypeID = model.BussinessEmailTypeClassTypeID;
                dto.TypeCode.ParentTypeCodeID = model.BussinessEmailTypeParentTypeCodeID;
            }

            return dto;
        }
    }
}
