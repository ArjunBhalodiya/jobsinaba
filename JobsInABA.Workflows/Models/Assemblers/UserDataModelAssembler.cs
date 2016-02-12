using System;
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
        public static UserDataModel ToDataModel(UserDTO userDTO, UserAccountDTO accountDTO, AddressDTO addressDTO, PhoneDTO phoneDTO, EmailDTO emailDTO)
        {

            UserDataModel model = null;

            if (userDTO != null)
            {
                model = new UserDataModel
                {
                    UserID = userDTO.UserID,
                    UserName = userDTO.UserName,
                    FirstName = userDTO.FirstName,
                    MiddleName = userDTO.MiddleName,
                    LastName = userDTO.LastName,
                    DOB = userDTO.DOB,
                    IsActive = userDTO.IsActive,
                    IsDeleted = userDTO.IsDeleted,
                    insuser = userDTO.insuser,
                    insdt = userDTO.insdt,
                    upduser = userDTO.upduser,
                    upddt = userDTO.upddt
                };

                if (accountDTO != null)
                {
                    model.UserAccountID = accountDTO.UserAccountID;
                    model.UserAccountinsdt = accountDTO.insdt;
                    model.UserAccountinsuser = accountDTO.insuser;
                    model.UserAccountIsActive = accountDTO.IsActive;
                    model.UserAccountIsDeleted = accountDTO.IsDeleted;
                    model.UserAccountPassword = accountDTO.Password;
                    model.UserAccountupddt = accountDTO.upddt;
                    model.UserAccountupduser = accountDTO.upduser;
                    model.UserAccountUserName = accountDTO.UserName;
                }

                if (addressDTO != null)
                {
                    model.UserAddressAddressTypeID = addressDTO.AddressTypeID;
                    model.UserAddressCity = addressDTO.City;
                    model.UserAddressCountryID = addressDTO.CountryID;
                    model.UserAddressID = addressDTO.AddressID;
                    model.UserAddressLine1 = addressDTO.Line1;
                    model.UserAddressLine2 = addressDTO.Line2;
                    model.UserAddressLine3 = addressDTO.Line3;
                    model.UserAddressState = addressDTO.State;
                    model.UserAddressTitle = addressDTO.Title;
                    model.UserAddressZipCode = addressDTO.ZipCode;

                }

                if (phoneDTO != null)
                {
                    model.UserPhoneCountryID = phoneDTO.CountryID;
                    model.UserPhoneExt = phoneDTO.Ext;
                    model.UserPhoneID = phoneDTO.PhoneID;
                    model.UserPhoneNumber = phoneDTO.Number;
                    model.UserPhoneTypeID = phoneDTO.PhoneTypeID;
                }

                if (emailDTO != null)
                {
                    model.UserEmailAddress = emailDTO.Address;
                    model.UserEmailID = emailDTO.EmailID;
                    model.UserEmailTypeID = emailDTO.EmailTypeID;
                }
            }

            return model;
        }

        public static UserDTO ToUserDTO(UserDataModel datamodel)
        {
            UserDTO dto = new UserDTO();
            if (datamodel != null)
            {
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

        public static UserAccountDTO ToUserAccountDTO(UserDataModel datamodel)
        {
            UserAccountDTO model=new UserAccountDTO();
            if (datamodel != null)
            {
                model.UserAccountID = datamodel.UserAccountID;
                model.insdt = datamodel.UserAccountinsdt;
                model.insuser = datamodel.UserAccountinsuser;
                model.IsActive = datamodel.UserAccountIsActive;
                model.IsDeleted = datamodel.UserAccountIsDeleted;
                model.Password = datamodel.UserAccountPassword;
                model.upddt = datamodel.UserAccountupddt;
                model.upduser = datamodel.UserAccountupduser;
                model.UserName = datamodel.UserAccountUserName;
            }
            return model;
        }

        public static AddressDTO ToAddressDTO(UserDataModel datamodel)
        {
            AddressDTO dto = new AddressDTO();
            if (datamodel != null)
            {
                dto.AddressID = datamodel.UserAddressID;
                dto.AddressTypeID = datamodel.UserAddressAddressTypeID;
                dto.City = datamodel.UserAddressCity;
                dto.CountryID = datamodel.UserAddressCountryID;
                dto.Line1 = datamodel.UserAddressLine1;
                dto.Line2 = datamodel.UserAddressLine2;
                dto.Line3 = datamodel.UserAddressLine3;
                dto.State = datamodel.UserAddressState;
                dto.Title = datamodel.UserAddressTitle;
                dto.ZipCode = datamodel.UserAddressZipCode;
            }

            return dto;
        }

        public static PhoneDTO ToPhoneDTO(UserDataModel datamodel)
        {
            PhoneDTO dto = new PhoneDTO();
            if (datamodel != null)
            {
                dto.CountryID = datamodel.UserPhoneCountryID;
                dto.Ext = datamodel.UserPhoneExt;
                dto.Number = datamodel.UserPhoneNumber;
                dto.PhoneID = datamodel.UserPhoneID;
                dto.PhoneTypeID = datamodel.UserPhoneTypeID;
            }

            return dto;
        }

        public static EmailDTO ToEmailDTO(UserDataModel datamodel)
        {
            EmailDTO dto = new EmailDTO();
            if (datamodel != null)
            {
                dto.Address = datamodel.UserEmailAddress;
                dto.EmailID = datamodel.UserEmailID;
                dto.EmailTypeID = datamodel.UserEmailTypeID;
            }

            return dto;
        }
    }
}
