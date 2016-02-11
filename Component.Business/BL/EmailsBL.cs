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
    public class EmailsBL
    {
        EmailsRepo _EmailRepo;

        private EmailsRepo oEmailRepo
        {
            get
            {
                if (_EmailRepo == null) _EmailRepo = new EmailsRepo();
                return _EmailRepo;
            }
        }

        public EmailDTO Get(int EmailID)
        {
            EmailDTO oEmailDTO = null;
            if (EmailID > 0)
            {
                Email oEmail = oEmailRepo.GetEmailByID(EmailID);
                if (oEmail != null)
                {
                    oEmailDTO = EmailAssembler.ToDTO(oEmail);
                    if (oEmail.TypeCode != null) oEmailDTO.TypeCode = TypeCodeAssembler.ToDTO(oEmail.TypeCode);
                    if (oEmail.TypeCode != null && oEmail.TypeCode.ClassType != null) oEmailDTO.TypeCode.ClassType = ClassTypeAssembler.ToDTO(oEmail.TypeCode.ClassType);
                }

            }

            return oEmailDTO;
        }

        public EmailDTO Create(EmailDTO oEmailDTO)
        {
            if (oEmailDTO != null)
            {
                return EmailAssembler.ToDTO(oEmailRepo.CreateEmail(EmailAssembler.ToEntity(oEmailDTO)));
            }

            return null;
        }

        public EmailDTO Update(EmailDTO oEmailDTO)
        {
            EmailDTO returnEmail = null;
            if (oEmailDTO != null && oEmailDTO.EmailID > 0)
            {
                oEmailRepo.UpdateEmail(EmailAssembler.ToEntity(oEmailDTO));
                returnEmail = oEmailDTO;
            }

            return returnEmail;
        }

        public bool Delete(int EmailID)
        {

            Boolean isDeleted = false;

            if (EmailID > 0)
            {
                isDeleted = oEmailRepo.DeleteEmail(EmailID);
            }

            return isDeleted;
        }
    }
}
