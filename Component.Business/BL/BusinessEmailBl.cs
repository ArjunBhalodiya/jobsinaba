using JobsInABA.DAL.Entities;
using JobsInABA.DAL.Repositories;
using JobsInABA.DTOs;
using JobsInABA.DTOs.Assemblers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsInABA.BL
{
    class BusinessEmailBL
    {
        BusinessEmailsRepos _BusinessEmailsRepos;

        private BusinessEmailsRepos oBusinessEmailsRepos
        {
            get
            {
                if (_BusinessEmailsRepos == null) _BusinessEmailsRepos = new BusinessEmailsRepos();
                return _BusinessEmailsRepos;
            }
        }

        public BusinessEmailDTO Get(int businessEmailsID)
        {
            BusinessEmailDTO oBusinessEmailsDTO = null;
            if (businessEmailsID > 0)
            {
                BusinessEmail oBusinessEmails = oBusinessEmailsRepos.GetBusinessEmail(businessEmailsID);
            }

            return oBusinessEmailsDTO;
        }

        public BusinessEmail Create(BusinessEmail oBusinessEmails)
        {
            if (oBusinessEmails != null)
            {
                return oBusinessEmailsRepos.CreateBusinessEmail(oBusinessEmails);
            }

            return null;
        }

        public BusinessEmailDTO Update(BusinessEmailDTO oBusinessEmailsDTO)
        {
            BusinessEmailDTO returnEmails = null;
            if (oBusinessEmailsDTO != null && oBusinessEmailsDTO.EmailID > 0)
            {
                oBusinessEmailsRepos.UpdateBusinessEmail(0, BusinessEmailAssembler.ToEntity(oBusinessEmailsDTO));
                returnEmails = oBusinessEmailsDTO;
            }

            return returnEmails;
        }

        public bool Delete(int BusinessEmailsID)
        {
            Boolean isDeleted = false;

            if (BusinessEmailsID > 0)
            {
                try
                {
                    oBusinessEmailsRepos.DeleteBusinessEmail(BusinessEmailsID);
                }
                catch
                {
                    return false;
                }
            }
            return isDeleted;
        }
    }
}
