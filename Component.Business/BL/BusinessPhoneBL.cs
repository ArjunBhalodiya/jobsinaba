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
    class BusinessPhoneBL
    {
        BusinessPhonesRepos _BusinessPhoneRepos;

        private BusinessPhonesRepos oBusinessPhoneRepos
        {
            get
            {
                if (_BusinessPhoneRepos == null) _BusinessPhoneRepos = new BusinessPhonesRepos();
                return _BusinessPhoneRepos;
            }
        }

        public BusinessPhoneDTO Get(int businessPhoneID)
        {
            BusinessPhoneDTO oBusinessPhoneDTO = null;
            if (businessPhoneID > 0)
            {
                BusinessPhone oBusinessPhone = oBusinessPhoneRepos.GetBusinessPhone(businessPhoneID);
            }

            return oBusinessPhoneDTO;
        }

        public BusinessPhone Create(BusinessPhone oBusinessPhone)
        {
            if (oBusinessPhone != null)
            {
                return oBusinessPhoneRepos.CreateBusinessPhone(oBusinessPhone);
            }

            return null;
        }

        public BusinessPhoneDTO Update(BusinessPhoneDTO oBusinessPhoneDTO)
        {
            BusinessPhoneDTO returnPhone = null;
            if (oBusinessPhoneDTO != null && oBusinessPhoneDTO.PhoneID > 0)
            {
                oBusinessPhoneRepos.UpdateBusinessPhone(0, BusinessPhoneAssembler.ToEntity(oBusinessPhoneDTO));
                returnPhone = oBusinessPhoneDTO;
            }

            return returnPhone;
        }

        public bool Delete(int BusinessPhoneID)
        {
            Boolean isDeleted = false;

            if (BusinessPhoneID > 0)
            {
                try
                {
                    oBusinessPhoneRepos.DeleteBusinessPhone(BusinessPhoneID);
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
