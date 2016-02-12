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
    public class UserAccountBL
    {
        UserAccountRepo _UserAccountRepo;

        private UserAccountRepo oUserAccountRepo
        {
            get
            {
                if (_UserAccountRepo == null) _UserAccountRepo = new UserAccountRepo();
                return _UserAccountRepo;
            }
        }

        public UserAccountDTO Get(int UserAccountID)
        {
            UserAccountDTO oUserAccountDTO = null;
            if (UserAccountID > 0)
            {
                UserAccount oUserAccount = oUserAccountRepo.GetUserAccountByID(UserAccountID);
            }

            return oUserAccountDTO;
        }

        public UserAccountDTO Create(UserAccountDTO oUserAccountDTO)
        {
            if (oUserAccountDTO != null)
            {
                oUserAccountRepo.CreateUserAccount(UserAccountAssembler.ToEntity(oUserAccountDTO));
                return oUserAccountDTO;
            }
            return null;
        }

        public UserAccountDTO Update(UserAccountDTO oUserAccountDTO)
        {
            UserAccountDTO returnUserAccount = null;
            if (oUserAccountDTO != null && oUserAccountDTO.UserAccountID > 0)
            {
                oUserAccountRepo.UpdateUserAccount(UserAccountAssembler.ToEntity(oUserAccountDTO));
                returnUserAccount = oUserAccountDTO;
            }

            return returnUserAccount;
        }

        public bool Delete(int UserAccountID)
        {

            Boolean isDeleted = false;

            if (UserAccountID > 0)
            {
                isDeleted = oUserAccountRepo.DeleteUserAccount(UserAccountID);
            }

            return isDeleted;
        }
    }
}
