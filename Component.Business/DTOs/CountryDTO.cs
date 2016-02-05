/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:19
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JobsInABA.DTOs
{
    [DataContract()]
    public partial class CountryDTO
    {
        [DataMember()]
        public Int32 CountryID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Abbreviation { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public String PhoneCode { get; set; }

        [DataMember()]
        public List<AddressDTO> Addresses { get; set; }

        public CountryDTO()
        {
        }

        public CountryDTO(Int32 countryID, String name, String abbreviation, String code, String phoneCode, List<AddressDTO> addresses)
        {
			this.CountryID = countryID;
			this.Name = name;
			this.Abbreviation = abbreviation;
			this.Code = code;
			this.PhoneCode = phoneCode;
			this.Addresses = addresses;
        }
    }
}
