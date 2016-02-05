﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsInABA.BL;
using JobsInABA.DTOs;

namespace JobsInABA.Workflows.Models.Assemblers
{
    public static class UserDataModelAssembler
    {
        public static UserDataModel ToDataModel(UserDTO oUserDTO, AddressDTO oPrimaryAddressDTO, PhoneDTO oPrimaryPhoneDTO, EmailDTO oPrimaryEmailDTO) {

            UserDataModel oUserDataModel = null;

            if (oUserDTO != null)
            {
                oUserDataModel = new UserDataModel
                {
                    UserID = oUserDTO.UserID,
                    UserName = oUserDTO.UserName,
                    FirstName = oUserDTO.FirstName,
                    MiddleName = oUserDTO.MiddleName,
                    LastName = oUserDTO.LastName,
                    DOB = oUserDTO.DOB,
                    IsActive = oUserDTO.IsActive,
                    IsDeleted = oUserDTO.IsDeleted,
                    insuser = oUserDTO.insuser,
                    insdt = oUserDTO.insdt,
                    upduser = oUserDTO.upduser,
                    upddt = oUserDTO.upddt
                };

                if (oPrimaryAddressDTO != null)
                {
                    oUserDataModel.PrimayAddress_AddressID = oPrimaryAddressDTO.AddressID;
                    oUserDataModel.PrimaryAddressTitle = oPrimaryAddressDTO.Title;
                    oUserDataModel.PrimaryAddressLine1 = oPrimaryAddressDTO.Line1;
                    oUserDataModel.PrimaryAddressLine2 = oPrimaryAddressDTO.Line2;
                    oUserDataModel.PrimaryAddressLine3 = oPrimaryAddressDTO.Line3;
                    oUserDataModel.PrimaryAddressCity = oPrimaryAddressDTO.City;
                    oUserDataModel.PrimaryAddressState = oPrimaryAddressDTO.State;
                    oUserDataModel.PrimaryAddressZipCode = oPrimaryAddressDTO.ZipCode;
                    oUserDataModel.PrimaryAddressCountryID = oPrimaryAddressDTO.CountryID;
                    oUserDataModel.PrimaryAddressCountryName = oPrimaryAddressDTO.Country.Name;
                    oUserDataModel.PrimaryAddressCountryAbbreviation = oPrimaryAddressDTO.Country.Abbreviation;
                    oUserDataModel.PrimaryAddressCountryCode = oPrimaryAddressDTO.Country.Code;
                    oUserDataModel.PrimaryAddressCountryPhoneCode = oPrimaryAddressDTO.Country.PhoneCode;
                    
                    oUserDataModel.PrimaryAddressTypeID = oPrimaryAddressDTO.AddressTypeID;
                    oUserDataModel.PrimaryAddressTypeName = oPrimaryAddressDTO.TypeCode.Name;
                    oUserDataModel.PrimaryAddressTypeCode = oPrimaryAddressDTO.TypeCode.Code;
                    oUserDataModel.PrimaryAddressTypeDescription = oPrimaryAddressDTO.TypeCode.Description;
                    oUserDataModel.PrimaryAddressTypeClassTypeID = oPrimaryAddressDTO.TypeCode.ClassTypeID;

                }

                if (oPrimaryPhoneDTO != null)
                {
                    oUserDataModel.PrimaryPhone_PhoneID = oPrimaryPhoneDTO.PhoneID;
                    oUserDataModel.PrimaryPhoneNumber = oPrimaryPhoneDTO.Number;
                    oUserDataModel.PrimaryPhoneExt = oPrimaryPhoneDTO.Ext;

                    oUserDataModel.PrimaryPhoneTypeID = oPrimaryPhoneDTO.TypeCode.TypeCodeID;
                    oUserDataModel.PrimaryPhoneTypeName = oPrimaryPhoneDTO.TypeCode.Name;
                    oUserDataModel.PrimaryPhoneTypeCode = oPrimaryPhoneDTO.TypeCode.Code;
                    oUserDataModel.PrimaryPhoneTypeDescription = oPrimaryPhoneDTO.TypeCode.Description;
                    oUserDataModel.PrimaryPhoneTypeClassTypeID = oPrimaryPhoneDTO.TypeCode.ClassTypeID;

                }
                
                if (oPrimaryEmailDTO != null)
                {
                    oUserDataModel.PrimaryEmail_EmailID = oPrimaryEmailDTO.EmailID;
                    oUserDataModel.PrimaryEmailAddress = oPrimaryEmailDTO.Address;

                    oUserDataModel.PrimaryEmailTypeID = oPrimaryPhoneDTO.TypeCode.TypeCodeID;
                    oUserDataModel.PrimaryEmailTypeName = oPrimaryEmailDTO.TypeCode.Name;
                    oUserDataModel.PrimaryEmailTypeCode = oPrimaryEmailDTO.TypeCode.Code;
                    oUserDataModel.PrimaryEmailTypeDescription = oPrimaryEmailDTO.TypeCode.Description;
                    oUserDataModel.PrimaryEmailTypeClassTypeID = oPrimaryEmailDTO.TypeCode.ClassTypeID;

                }
            }

            return oUserDataModel;
        }

        public static UserDTO ToDTO(UserDataModel datamodel) {

            UserDTO dto = new UserDTO();
            if (datamodel != null) { 
                dto.UserID = datamodel.UserID;
                dto.UserName = datamodel.UserName;
                dto.FirstName = datamodel.FirstName;
                dto.MiddleName = datamodel.MiddleName;
                dto.LastName = datamodel.LastName;
                dto.DOB = datamodel.DOB;
                dto.IsActive = datamodel.IsActive;
                dto.IsDeleted = datamodel.IsDeleted;
                dto.insuser = datamodel.insuser;
                dto.insdt = datamodel.insdt;
                dto.upduser = datamodel.upduser;
                dto.upddt = datamodel.upddt;
            }

            return dto;
        }
    }
}