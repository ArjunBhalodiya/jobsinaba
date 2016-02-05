using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.DTOs;
using JobsInABA.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class UsersBL
    {
        UsersRepo _UsersRepo;

        private UsersRepo oUsersRepo {
            get {
                if (_UsersRepo == null) _UsersRepo = new UsersRepo();
                return _UsersRepo;
            }
        }

        public UserDTO Get(int UserID) {
            UserDTO oUserDTO = null;
            if (UserID > 0) {
                User oUser = oUsersRepo.GetUserByID(UserID);
                if (oUser != null) {
                    oUserDTO = UserAssembler.ToDTO(oUser);

                    /*
                    if (oUser.UserAddresses != null && oUser.UserAddresses.Count > 0) {
                        oUserDTO.UserAddresses = UserAddressAssembler.ToDTOs(oUser.UserAddresses);
                    }

                    if (oUser.UserEmails != null && oUser.UserEmails.Count > 0) {
                        oUserDTO.UserEmails = UserEmailAssembler.ToDTOs(oUser.UserEmails);
                    }

                    if (oUser.UserPhones != null && oUser.UserPhones.Count > 0)
                    {
                        oUserDTO.UserPhones = UserPhoneAssembler.ToDTOs(oUser.UserPhones);
                    }
                    */
                }

            }

            return oUserDTO;
        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> oUserDTOs = new List<UserDTO>();
            List<User> oUsers = oUsersRepo.GetUsers().ToList();
            if (oUsers != null && oUsers.Count > 0)
            {
                oUserDTOs = UserAssembler.ToDTOs(oUsers);

                /*
                if (oUser.UserAddresses != null && oUser.UserAddresses.Count > 0)
                {
                    oUserDTO.UserAddresses = UserAddressAssembler.ToDTOs(oUser.UserAddresses);
                }

                if (oUser.UserEmails != null && oUser.UserEmails.Count > 0)
                {
                    oUserDTO.UserEmails = UserEmailAssembler.ToDTOs(oUser.UserEmails);
                }

                if (oUser.UserPhones != null && oUser.UserPhones.Count > 0)
                {
                    oUserDTO.UserPhones = UserPhoneAssembler.ToDTOs(oUser.UserPhones);
                }
                */
            }
            return oUserDTOs;
        }

        public UserDTO Create(UserDTO oUserDTO)
        {
            if (oUserDTO != null) {
                User oUser = UserAssembler.ToEntity(oUserDTO);
                return UserAssembler.ToDTO(oUsersRepo.CreateUser(oUser));
            }

            return null;
        }

        public UserDTO Update(UserDTO oUserDTO)
        {
            UserDTO returnUser = null;
            if (oUserDTO != null && oUserDTO.UserID > 0)
            {
                oUsersRepo.UpdateUser(UserAssembler.ToEntity(oUserDTO));
                returnUser = oUserDTO;
            }

            return returnUser;
        }

        public bool Delete(int UserID)
        {

            Boolean isDeleted = false;

            if (UserID > 0) {
                isDeleted = oUsersRepo.DeleteUser(UserID);
            }

            return isDeleted;
        }
    }
}
