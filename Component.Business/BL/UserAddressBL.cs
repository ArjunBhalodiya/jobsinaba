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
    public class UserAddressBL
    {
        UserAddressesRepo _UserAddressRepo;

        private UserAddressesRepo oUserAddressRepo
        {
            get
            {
                if (_UserAddressRepo == null) _UserAddressRepo = new UserAddressesRepo();
                return _UserAddressRepo;
            }
        }

        public UserAddressDTO Get(int UserAddressID)
        {
            UserAddressDTO oUserAddressDTO = null;
            if (UserAddressID > 0)
            {
                UserAddress oUserAddress = oUserAddressRepo.GetUserAddress(UserAddressID);
            }

            return oUserAddressDTO;
        }

        public UserAddress Create(UserAddress oUserAddress)
        {
            if (oUserAddress != null)
            {
                return oUserAddressRepo.CreateUserAddress(oUserAddress);
            }

            return null;
        }

        public UserAddressDTO Update(UserAddressDTO oUserAddressDTO)
        {
            UserAddressDTO returnUserAddress = null;
            if (oUserAddressDTO != null && oUserAddressDTO.UserAddressID > 0)
            {
                oUserAddressRepo.UpdateUserAddress(0, UserAddressAssembler.ToEntity(oUserAddressDTO));
                returnUserAddress = oUserAddressDTO;
            }

            return returnUserAddress;
        }

        public bool Delete(int UserAddressID)
        {
            try
            {
                oUserAddressRepo.DeleteUserAddress(UserAddressID);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
