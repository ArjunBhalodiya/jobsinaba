using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsInABA.BL;
using JobsInABA.DTOs;

namespace JobsInABA.Workflows.Models.Assemblers
{
    public static class AddressDataModelAssembler
    {
        public static AddressDataModel ToDataModel(AddressDTO dto) { 
            
            AddressDataModel datamodel = new AddressDataModel();
            
            if(dto != null) {
                datamodel.AddressID = dto.AddressID;
			    datamodel.Title = dto.Title;
			    datamodel.Line1 = dto.Line1;
			    datamodel.Line2 = dto.Line2;
			    datamodel.Line3 = dto.Line3;
			    datamodel.City = dto.City;
			    datamodel.State = dto.State;
			    datamodel.ZipCode = dto.ZipCode;
                datamodel.AddressTypeID = dto.AddressTypeID;
                datamodel.AddressIsPrimary = false;

                if(dto.Country != null) {
                    CountryDTO countrydto = dto.Country;
			        datamodel.AddressCountryID = countrydto.CountryID;
			        datamodel.AddressCountryName = countrydto.Name;
			        datamodel.AddressCountryAbbreviation = countrydto.Abbreviation;
			        datamodel.AddressCountryCode = countrydto.Code;
			        datamodel.AddressCountryPhoneCode = countrydto.PhoneCode;
                }

                if(dto.TypeCode != null) {
                    TypeCodeDTO typecodedto = dto.TypeCode;
                    datamodel.AddressTypeName = typecodedto.Name;
			        datamodel.AddressTypeCode = typecodedto.Code;
			        datamodel.AddressTypeDescription = typecodedto.Description;
			        datamodel.AddressTypeClassTypeID = typecodedto.ClassTypeID;
                }
            }

            return datamodel;
        }

        public static AddressDTO ToDTO(AddressDataModel datamodel)
        {
            AddressDTO dto = new AddressDTO();

            if (datamodel != null)
            {
                dto.AddressID = datamodel.AddressID;
                dto.Title = datamodel.Title;
                dto.Line1 = datamodel.Line1;
                dto.Line2 = datamodel.Line2;
                dto.Line3 = datamodel.Line3;
                dto.City = datamodel.City;
                dto.State = datamodel.State;
                dto.ZipCode = datamodel.ZipCode;
                dto.AddressTypeID = datamodel.AddressTypeID;
            }

            return dto;
        }

        public static IEnumerable<AddressDataModel> ToDataModels(IEnumerable<AddressDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => ToDataModel(e)).ToList();
        }


    }
}
