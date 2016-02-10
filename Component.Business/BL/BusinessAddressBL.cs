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
    class BusinessAddressBL
    {
        BusinessAddressesRepos _BusinessAddressesRepo;

        private BusinessAddressesRepos oBusinessAddressesRepo
        {
            get
            {
                if (_BusinessAddressesRepo == null) _BusinessAddressesRepo = new BusinessAddressesRepos();
                return _BusinessAddressesRepo;
            }
        }

        public BusinessAddressDTO Get(int businessAddressID)
        {
            BusinessAddressDTO oBusinessAddressDTO = null;
            if (businessAddressID > 0)
            {
                BusinessAddress oBusinessAddress = oBusinessAddressesRepo.GetBusinessAddress(businessAddressID);
            }

            return oBusinessAddressDTO;
        }

        public BusinessAddress Create(BusinessAddress oBusinessAddress)
        {
            if (oBusinessAddress != null)
            {
                return oBusinessAddressesRepo.CreateBusinessAddress(oBusinessAddress);
            }

            return null;
        }

        public BusinessAddressDTO Update(BusinessAddressDTO oBusinessAddressDTO)
        {
            BusinessAddressDTO returnAddress = null;
            if (oBusinessAddressDTO != null && oBusinessAddressDTO.AddressID > 0)
            {
                oBusinessAddressesRepo.UpdateBusinessAddress(0, BusinessAddressAssembler.ToEntity(oBusinessAddressDTO));
                returnAddress = oBusinessAddressDTO;
            }

            return returnAddress;
        }

        public bool Delete(int BusinessAddressID)
        {
            Boolean isDeleted = false;

            if (BusinessAddressID > 0)
            {
                try
                {
                    oBusinessAddressesRepo.DeleteBusinessAddress(BusinessAddressID);
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
