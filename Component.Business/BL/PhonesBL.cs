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
    public class PhonesBL
    {
        PhonesRepo _PhoneRepo;

        private PhonesRepo oPhoneRepo
        {
            get
            {
                if (_PhoneRepo == null) _PhoneRepo = new PhonesRepo();
                return _PhoneRepo;
            }
        }

        public PhoneDTO Get(int PhoneID)
        {
            PhoneDTO oPhoneDTO = null;
            if (PhoneID > 0)
            {
                Phone oPhone = oPhoneRepo.GetPhoneByID(PhoneID);
                if (oPhone != null)
                {
                    oPhoneDTO = PhoneAssembler.ToDTO(oPhone);
                    if (oPhone.TypeCode != null) oPhoneDTO.TypeCode = TypeCodeAssembler.ToDTO(oPhone.TypeCode);
                    if (oPhone.TypeCode != null && oPhone.TypeCode.ClassType != null) oPhoneDTO.TypeCode.ClassType = ClassTypeAssembler.ToDTO(oPhone.TypeCode.ClassType);
                }

            }

            return oPhoneDTO;
        }

        public PhoneDTO Create(PhoneDTO oPhoneDTO)
        {
            if (oPhoneDTO != null)
            {
                return PhoneAssembler.ToDTO(oPhoneRepo.CreatePhone(PhoneAssembler.ToEntity(oPhoneDTO)));
            }

            return null;
        }

        public PhoneDTO Update(PhoneDTO oPhoneDTO)
        {
            PhoneDTO returnPhone = null;
            if (oPhoneDTO != null && oPhoneDTO.PhoneID > 0)
            {
                oPhoneRepo.UpdatePhone(PhoneAssembler.ToEntity(oPhoneDTO));
                returnPhone = oPhoneDTO;
            }

            return returnPhone;
        }

        public bool Delete(int PhoneID)
        {

            Boolean isDeleted = false;

            if (PhoneID > 0)
            {
                isDeleted = oPhoneRepo.DeletePhone(PhoneID);
            }

            return isDeleted;
        }
    }
}
