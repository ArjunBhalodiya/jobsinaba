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
    public class UserWorkflows
    {
        UsersBL _UsersBL;
        AddressBL _AddressBL;
        EmailsBL _EmailsBL;
        PhonesBL _PhonesBL;
        AddressWorkflows _AddressWorkflows;

        public UserDataModel GetUser(int id) {

            UserDataModel oUserDataModel = null;
            if (id > 0)
            {
                UserDTO oUserDTO = oUsersBL.Get(id);

                if (oUserDTO != null) {
                    oUserDataModel = GetUser(oUserDTO);
                }
            }

            return oUserDataModel;
        }

        public UserDataModel GetUser(UserDTO oUserDTO)
        {

            UserDataModel oUserDataModel = null;
            if (oUserDTO != null)
            {

                UserAddressDTO oUserAddressDTO = (oUserDTO.UserAddresses != null) ? oUserDTO.UserAddresses.Where(o => o.IsPrimary).FirstOrDefault() : null;
                AddressDTO oPrimaryAddressDTO = (oUserAddressDTO != null) ? oUserAddressDTO.Address : null; //oAddressBL.Get(oUserAddressDTO.AddressID) : null;

                UserPhoneDTO oUserPhoneDTO = (oUserDTO.UserPhones != null) ? oUserDTO.UserPhones.Where(o => o.IsPrimary).FirstOrDefault() : null;
                PhoneDTO oPrimaryPhoneDTO = (oUserPhoneDTO != null) ? oUserPhoneDTO.Phone : null; //oPhonesBL.Get(oUserPhoneDTO.PhoneID) : null;

                UserEmailDTO oUserEmailDTO = (oUserDTO.UserEmails != null) ? oUserDTO.UserEmails.Where(o => o.IsPrimary).FirstOrDefault() : null;
                EmailDTO oPrimaryEmailDTO = (oUserEmailDTO != null) ? oUserEmailDTO.Email : null; //oEmailsBL.Get(oUserEmailDTO.EmailID) : null;

                oUserDataModel = UserDataModelAssembler.ToDataModel(oUserDTO, oPrimaryAddressDTO, oPrimaryPhoneDTO, oPrimaryEmailDTO);
                oUserDataModel.PrimaryUserAddressID = (oUserAddressDTO != null) ? oUserAddressDTO.UserAddressID : 0;
                oUserDataModel.PrimaryUserPhoneID = (oUserPhoneDTO != null) ? oUserPhoneDTO.UserPhoneID : 0;
                oUserDataModel.PrimaryUserEmailID = (oUserEmailDTO != null) ? oUserEmailDTO.UserEmailID : 0;

                //Get All the Addresses.
                oUserDataModel.Addresses = (oUserDTO.UserAddresses != null) ? oAddressWorkflows.GetAddresses(oUserDTO.UserAddresses.Select(ua => ua.Address).ToList()) : null;
            }
            return oUserDataModel;
        }

        public List<UserDataModel> GetUsers()
        {

            List<UserDataModel> oUserDataModels = new List<UserDataModel>();
            
            List<UserDTO> oUserDTOs = oUsersBL.GetUsers();

            oUserDataModels = oUserDTOs.Select(userdto => GetUser(userdto)).ToList();

            return oUserDataModels;
        }

        public UserDataModel CreateUser(UserDataModel oUserDataModel) {
            
            if (oUserDataModel != null) {
                UserDTO oUserDTO = new UserDTO();
                oUserDTO = UserDataModelAssembler.ToDTO(oUserDataModel);

                if (oUserDTO != null) {
                    oUsersBL.Create(oUserDTO);
                }
            }

            return oUserDataModel;
        }

        private UsersBL oUsersBL {
            get {
                if (_UsersBL == null) _UsersBL = new UsersBL();
                return _UsersBL;
            }
        }

        private AddressBL oAddressBL {
            get {
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
