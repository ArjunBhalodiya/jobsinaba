/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:13
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
    public partial class BusinessAddressDTO
    {
        [DataMember()]
        public Int32 BusinessAddressID { get; set; }

        [DataMember()]
        public Int32 BusinessID { get; set; }

        [DataMember()]
        public Int32 AddressID { get; set; }

        [DataMember()]
        public Boolean IsPrimary { get; set; }

        [DataMember()]
        public AddressDTO Address { get; set; }

        [DataMember()]
        public BusinessDTO Business { get; set; }

        public BusinessAddressDTO()
        {
        }

        public BusinessAddressDTO(Int32 businessAddressID, Int32 businessID, Int32 addressID, Boolean isPrimary, AddressDTO address, BusinessDTO business)
        {
			this.BusinessAddressID = businessAddressID;
			this.BusinessID = businessID;
			this.AddressID = addressID;
			this.IsPrimary = isPrimary;
			this.Address = address;
			this.Business = business;
        }
    }
}