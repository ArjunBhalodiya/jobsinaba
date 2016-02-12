using System.Collections.Generic;
using System.Linq;
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
        UserAccountBL _AccountBL;
        EmailsBL _EmailsBL;
        PhonesBL _PhonesBL;
        AddressWorkflows _AddressWorkflows;

        public UserDataModel GetUser(int id)
        {
            UserDataModel userDataModel = null;
            if (id > 0)
            {
                UserDTO userDTO = usersBL.Get(id);

                if (userDTO != null)
                {
                    userDataModel = GetUser(userDTO);
                }
            }
            return userDataModel;
        }

        public UserDataModel GetUser(UserDTO userDTO)
        {
            UserDataModel userDataModel = null;
            if (userDTO != null)
            {
                UserAddressDTO userAddressDTO = (userDTO.UserAddresses != null) ? userDTO.UserAddresses.Where(o => o.IsPrimary).FirstOrDefault() : null;
                AddressDTO oPrimaryAddressDTO = (userAddressDTO != null) ? userAddressDTO.Address : null;

                UserAccountDTO userAccountDTO = (userDTO.UserAddresses != null) ? userDTO.UserAccounts.FirstOrDefault(o => o.IsActive == true) : null;

                UserPhoneDTO userPhoneDTO = (userDTO.UserPhones != null) ? userDTO.UserPhones.Where(o => o.IsPrimary).FirstOrDefault() : null;
                PhoneDTO oPrimaryPhoneDTO = (userPhoneDTO != null) ? userPhoneDTO.Phone : null;

                UserEmailDTO userEmailDTO = (userDTO.UserEmails != null) ? userDTO.UserEmails.Where(o => o.IsPrimary).FirstOrDefault() : null;
                EmailDTO oPrimaryEmailDTO = (userEmailDTO != null) ? userEmailDTO.Email : null;

                userDataModel = UserDataModelAssembler.ToDataModel(userDTO, userAccountDTO, oPrimaryAddressDTO, oPrimaryPhoneDTO, oPrimaryEmailDTO);
                userDataModel.UserAddressID = (userAddressDTO != null) ? userAddressDTO.UserAddressID : 0;
                userDataModel.UserPhoneID = (userPhoneDTO != null) ? userPhoneDTO.UserPhoneID : 0;
                userDataModel.UserEmailID = (userEmailDTO != null) ? userEmailDTO.UserEmailID : 0;
            }
            return userDataModel;
        }

        public List<UserDataModel> GetUsers()
        {
            List<UserDataModel> userDataModels = new List<UserDataModel>();

            List<UserDTO> userDTOs = usersBL.GetUsers();

            userDataModels = userDTOs.Select(userdto => GetUser(userdto)).ToList();

            return userDataModels;
        }

        public UserDataModel CreateUser(UserDataModel userDataModel)
        {
            if (userDataModel != null)
            {
                UserDTO userDTO = new UserDTO();
                UserAccountDTO userAccountDTO = new UserAccountDTO();
                PhoneDTO oPhoneDTO = new PhoneDTO();
                EmailDTO oEmailDTO = new EmailDTO();
                AddressDTO oAddressDTO = new AddressDTO();

                userDTO = UserDataModelAssembler.ToUserDTO(userDataModel);
                userAccountDTO = UserDataModelAssembler.ToUserAccountDTO(userDataModel);
                oPhoneDTO = UserDataModelAssembler.ToPhoneDTO(userDataModel);
                oEmailDTO = UserDataModelAssembler.ToEmailDTO(userDataModel);
                oAddressDTO = UserDataModelAssembler.ToAddressDTO(userDataModel);

                if (userDTO != null)
                {
                    userDTO = usersBL.Create(userDTO);
                }
                if (userAccountDTO != null)
                {
                    userAccountDTO = AccountBL.Create(userAccountDTO);
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

            return userDataModel;
        }

        public UserDataModel UpdateUser(UserDataModel userDataModel)
        {
            if (userDataModel != null)
            {
                UserDTO userDTO = new UserDTO();
                UserAccountDTO userAccountDTO = new UserAccountDTO();
                PhoneDTO oPhoneDTO = new PhoneDTO();
                EmailDTO oEmailDTO = new EmailDTO();
                AddressDTO oAddressDTO = new AddressDTO();

                userDTO = UserDataModelAssembler.ToUserDTO(userDataModel);
                userAccountDTO = UserDataModelAssembler.ToUserAccountDTO(userDataModel);
                oPhoneDTO = UserDataModelAssembler.ToPhoneDTO(userDataModel);
                oEmailDTO = UserDataModelAssembler.ToEmailDTO(userDataModel);
                oAddressDTO = UserDataModelAssembler.ToAddressDTO(userDataModel);

                if (userDTO != null)
                {
                    userDTO = usersBL.Update(userDTO);
                }
                if (userAccountDTO != null)
                {
                    userAccountDTO = AccountBL.Update(userAccountDTO);
                }
                if (oPhoneDTO != null)
                {
                    oPhoneDTO = oPhonesBL.Update(oPhoneDTO);
                }
                if (oEmailDTO != null)
                {
                    oEmailsBL.Update(oEmailDTO);
                }
                if (oAddressDTO != null)
                {
                    oAddressBL.Update(oAddressDTO);
                }
            }

            return userDataModel;
        }

        public bool DeleteUser(int id)
        {
            return AccountBL.Delete(id);
        }

        private UserAccountBL AccountBL
        {
            get
            {
                if (_AccountBL == null) _AccountBL = new UserAccountBL();
                return _AccountBL;
            }
        }

        private UsersBL usersBL
        {
            get
            {
                if (_UsersBL == null) _UsersBL = new UsersBL();
                return _UsersBL;
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
