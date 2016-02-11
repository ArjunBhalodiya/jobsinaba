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
    public class UserEmailBL
    {
        UserEmailsRepo _UserEmailRepo;

        private UserEmailsRepo oUserEmailRepo
        {
            get
            {
                if (_UserEmailRepo == null) _UserEmailRepo = new UserEmailsRepo();
                return _UserEmailRepo;
            }
        }

        public UserEmailDTO Get(int UserEmailID)
        {
            UserEmailDTO oUserEmailDTO = null;
            if (UserEmailID > 0)
            {
                UserEmail oUserEmail = oUserEmailRepo.GetUserEmail(UserEmailID);
            }

            return oUserEmailDTO;
        }

        public UserEmail Create(UserEmail oUserEmail)
        {
            if (oUserEmail != null)
            {
                return oUserEmailRepo.CreateUserEmail(oUserEmail);
            }

            return null;
        }

        public UserEmailDTO Update(UserEmailDTO oUserEmailDTO)
        {
            UserEmailDTO returnUserEmail = null;
            if (oUserEmailDTO != null && oUserEmailDTO.UserEmailID > 0)
            {
                oUserEmailRepo.UpdateUserEmail(0, UserEmailAssembler.ToEntity(oUserEmailDTO));
                returnUserEmail = oUserEmailDTO;
            }

            return returnUserEmail;
        }

        public bool Delete(int UserEmailID)
        {
            try
            {
                oUserEmailRepo.DeleteUserEmail(UserEmailID);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
