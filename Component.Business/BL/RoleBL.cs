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
    class RoleBL
    {
        RolesRepos _RoleRepos;

        private RolesRepos oRoleRepos
        {
            get
            {
                if (_RoleRepos == null) _RoleRepos = new RolesRepos();
                return _RoleRepos;
            }
        }

        public RoleDTO Get(int RoleID)
        {
            RoleDTO oRoleDTO = null;
            if (RoleID > 0)
            {
                Role oRole = oRoleRepos.GetRole(RoleID);
            }

            return oRoleDTO;
        }

        public Role Create(Role oRole)
        {
            if (oRole != null)
            {
                return oRoleRepos.CreateRole(oRole);
            }

            return null;
        }

        public RoleDTO Update(RoleDTO oRoleDTO)
        {
            RoleDTO returnUserMap = null;
            if (oRoleDTO != null && oRoleDTO.RoleID > 0)
            {
                oRoleRepos.UpdateRole(0, RoleAssembler.ToEntity(oRoleDTO));
                returnUserMap = oRoleDTO;
            }

            return returnUserMap;
        }

        public bool Delete(int RoleID)
        {
            Boolean isDeleted = false;

            if (RoleID > 0)
            {
                try
                {
                    oRoleRepos.DeleteRole(RoleID);
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