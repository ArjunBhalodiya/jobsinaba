﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobsInABA.DAL.Repositories;
using JobsInABA.DAL.Entities;
using JobsInABA.DTOs;
using JobsInABA.DTOs.Assemblers;

namespace JobsInABA.BL.BL
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
