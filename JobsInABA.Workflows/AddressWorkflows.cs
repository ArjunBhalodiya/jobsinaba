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
        public AddressDataModel GetAddress(AddressDTO dto) {
            return AddressDataModelAssembler.ToDataModel(dto);
        }

        public IEnumerable<AddressDataModel> GetAddresses(IEnumerable<AddressDTO> dtos)
        {
            return AddressDataModelAssembler.ToDataModels(dtos);
        }
    }
}
