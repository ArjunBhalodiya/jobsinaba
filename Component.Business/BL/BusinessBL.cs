using System;
using System.Collections.Generic;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.DTOs;
using JobsInABA.DTOs.Assemblers;

namespace JobsInABA.BL
{
    public class BusinessBL
    {
        BusinessRepo _BusinessRepo;
        private BusinessRepo oBusinessRepo
        {
            get
            {
                if (_BusinessRepo == null) _BusinessRepo = new BusinessRepo();
                return _BusinessRepo;
            }
        }

        public List<BusinessDTO> Get()
        {
            return BusinessAssembler.ToDTOs(oBusinessRepo.GetBusinesss());
        }

        public BusinessDTO Get(int BusinessID)
        {
            BusinessDTO oBusinessDTO = null;
            if (BusinessID > 0)
            {
                Business oBusiness = oBusinessRepo.GetBusinessByID(BusinessID);
                if (oBusiness != null) oBusinessDTO = BusinessAssembler.ToDTO(oBusiness);
            }

            return oBusinessDTO;
        }

        public Business Create(Business oBusiness)
        {
            if (oBusiness != null)
            {
                return oBusinessRepo.CreateBusiness(oBusiness);
            }

            return null;
        }

        public BusinessDTO Create(BusinessDTO businessDTO)
        {
            if (businessDTO != null)
            {
                return BusinessAssembler.ToDTO(oBusinessRepo.CreateBusiness(BusinessAssembler.ToEntity(businessDTO)));
            }

            return null;
        }

        public BusinessDTO Update(BusinessDTO oBusinessDTO)
        {
            BusinessDTO returnBusiness = null;
            if (oBusinessDTO != null && oBusinessDTO.BusinessID > 0)
            {
                oBusinessRepo.UpdateBusiness(BusinessAssembler.ToEntity(oBusinessDTO));
                returnBusiness = oBusinessDTO;
            }

            return returnBusiness;
        }

        public bool Delete(int BusinessID)
        {

            Boolean isDeleted = false;

            if (BusinessID > 0)
            {
                isDeleted = oBusinessRepo.DeleteBusiness(BusinessID);
            }

            return isDeleted;
        }
    }
}
