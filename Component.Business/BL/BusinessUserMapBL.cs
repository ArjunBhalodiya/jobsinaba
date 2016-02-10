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
    class BusinessUserMapBL
    {
        BusinessUserMapsRepos _BusinessUserMapRepos;

        private BusinessUserMapsRepos oBusinessUserMapRepos
        {
            get
            {
                if (_BusinessUserMapRepos == null) _BusinessUserMapRepos = new BusinessUserMapsRepos();
                return _BusinessUserMapRepos;
            }
        }

        public BusinessUserMapDTO Get(int businessUserMapID)
        {
            BusinessUserMapDTO oBusinessUserMapDTO = null;
            if (businessUserMapID > 0)
            {
                BusinessUserMap oBusinessUserMap = oBusinessUserMapRepos.GetBusinessUserMap(businessUserMapID);
            }

            return oBusinessUserMapDTO;
        }

        public BusinessUserMap Create(BusinessUserMap oBusinessUserMap)
        {
            if (oBusinessUserMap != null)
            {
                return oBusinessUserMapRepos.CreateBusinessUserMap(oBusinessUserMap);
            }

            return null;
        }

        public BusinessUserMapDTO Update(BusinessUserMapDTO oBusinessUserMapDTO)
        {
            BusinessUserMapDTO returnUserMap = null;
            if (oBusinessUserMapDTO != null && oBusinessUserMapDTO.BusinessUserMapID > 0)
            {
                oBusinessUserMapRepos.UpdateBusinessUserMap(0, BusinessUserMapAssembler.ToEntity(oBusinessUserMapDTO));
                returnUserMap = oBusinessUserMapDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int BusinessUserMapID)
        {
            Boolean isDeleted = false;

            if (BusinessUserMapID > 0)
            {
                try
                {
                    oBusinessUserMapRepos.DeleteBusinessUserMap(BusinessUserMapID);
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