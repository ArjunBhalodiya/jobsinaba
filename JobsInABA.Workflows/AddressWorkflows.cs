using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using JobsInABA.BL;
using JobsInABA.DTOs;
using JobsInABA.Workflows.Models;
using JobsInABA.Workflows.Models.Assemblers;

namespace JobsInABA.Workflows
{
    public class AddressWorkflows
    {
        AddressBL _Address;

        public List<AddressDataModel> GetAddresses()
        {
            List<AddressDataModel> addressDataModels = new List<AddressDataModel>();

            List<AddressDTO> addressDTOs = addressBL.Get();

            return AddressDataModelAssembler.ToDataModels(addressDTOs).ToList();
        }

        public IEnumerable<AddressDataModel> GetAddresses(IEnumerable<AddressDTO> dtos)
        {
            return AddressDataModelAssembler.ToDataModels(dtos);
        }

        public AddressDataModel GetAddress(int id)
        {
            if (id > 0)
            {
                AddressDTO addressDTO = addressBL.Get(id);
                return AddressDataModelAssembler.ToDataModel(addressDTO);
            }

            return null;
        }

        public AddressDataModel Create(AddressDataModel addressDataModel)
        {
            if (addressDataModel != null)
            {
                var addressDTO = AddressDataModelAssembler.ToDTO(addressDataModel);

                if (addressDTO != null)
                {
                    addressDTO = addressBL.Create(AddressDataModelAssembler.ToDTO(addressDataModel));
                }
            }
            return addressDataModel;
        }

        public AddressBL addressBL
        {
            get { return new AddressBL(); }
        }
    }
}
