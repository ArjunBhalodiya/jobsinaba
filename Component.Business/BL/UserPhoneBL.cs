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
    public class UserPhoneBL
    {
        UserPhonesRepo _UserPhoneRepo;

        private UserPhonesRepo oUserPhoneRepo
        {
            get
            {
                if (_UserPhoneRepo == null) _UserPhoneRepo = new UserPhonesRepo();
                return _UserPhoneRepo;
            }
        }

        public UserPhoneDTO Get(int UserPhoneID)
        {
            UserPhoneDTO oUserPhoneDTO = null;
            if (UserPhoneID > 0)
            {
                UserPhone oUserPhone = oUserPhoneRepo.GetUserPhone(UserPhoneID);
            }

            return oUserPhoneDTO;
        }

        public UserPhone Create(UserPhone oUserPhone)
        {
            if (oUserPhone != null)
            {
                return oUserPhoneRepo.CreateUserPhone(oUserPhone);
            }

            return null;
        }

        public UserPhoneDTO Update(UserPhoneDTO oUserPhoneDTO)
        {
            UserPhoneDTO returnUserPhone = null;
            if (oUserPhoneDTO != null && oUserPhoneDTO.UserPhoneID > 0)
            {
                oUserPhoneRepo.UpdateUserPhone(0, UserPhoneAssembler.ToEntity(oUserPhoneDTO));
                returnUserPhone = oUserPhoneDTO;
            }

            return returnUserPhone;
        }

        public bool Delete(int UserPhoneID)
        {
            try
            {
                oUserPhoneRepo.DeleteUserPhone(UserPhoneID);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
