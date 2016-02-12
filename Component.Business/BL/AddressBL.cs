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
    public class AddressBL
    {
        AddressRepo _AddressRepo;

        private AddressRepo oAddressRepo
        {
            get
            {
                if (_AddressRepo == null) _AddressRepo = new AddressRepo();
                return _AddressRepo;
            }
        }

        public List<AddressDTO> Get()
        {
            IEnumerable<Address> oAddress = oAddressRepo.GetAddress();
            return AddressAssembler.ToDTOs(oAddress);
        }

        public AddressDTO Get(int AddressID)
        {
            AddressDTO oAddressDTO = null;
            if (AddressID > 0)
            {
                Address oAddress = oAddressRepo.GetAddressByID(AddressID);
                if (oAddress != null)
                {
                    oAddressDTO = AddressAssembler.ToDTO(oAddress);
                    if (oAddress.Country != null) oAddressDTO.Country = CountryAssembler.ToDTO(oAddress.Country);
                    if (oAddress.TypeCode != null) oAddressDTO.TypeCode = TypeCodeAssembler.ToDTO(oAddress.TypeCode);
                    if (oAddress.TypeCode != null && oAddress.TypeCode.ClassType != null) oAddressDTO.TypeCode.ClassType = ClassTypeAssembler.ToDTO(oAddress.TypeCode.ClassType);
                }

            }

            return oAddressDTO;
        }

        public AddressDTO Create(AddressDTO oAddressDTO)
        {
            if (oAddressDTO != null)
            {
                return AddressAssembler.ToDTO(oAddressRepo.CreateAddress(AddressAssembler.ToEntity(oAddressDTO)));
            }

            return null;
        }

        public AddressDTO Update(AddressDTO oAddressDTO)
        {
            AddressDTO returnAddress = null;
            if (oAddressDTO != null && oAddressDTO.AddressID > 0)
            {
                oAddressRepo.UpdateAddress(AddressAssembler.ToEntity(oAddressDTO));
                returnAddress = oAddressDTO;
            }

            return returnAddress;
        }

        public bool Delete(int AddressID)
        {

            Boolean isDeleted = false;

            if (AddressID > 0)
            {
                isDeleted = oAddressRepo.DeleteAddress(AddressID);
            }

            return isDeleted;
        }
    }
}
