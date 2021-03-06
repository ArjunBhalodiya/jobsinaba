/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:16
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
    public partial class BusinessPhoneDTO
    {
        [DataMember()]
        public Int32 BusinessPhoneID { get; set; }

        [DataMember()]
        public Int32 BusinessID { get; set; }

        [DataMember()]
        public Int32 PhoneID { get; set; }

        [DataMember()]
        public Boolean IsPrimary { get; set; }

        [DataMember()]
        public BusinessDTO Business { get; set; }

        [DataMember()]
        public PhoneDTO Phone { get; set; }

        public BusinessPhoneDTO()
        {
        }

        public BusinessPhoneDTO(Int32 businessPhoneID, Int32 businessID, Int32 phoneID, Boolean isPrimary, BusinessDTO business, PhoneDTO phone)
        {
			this.BusinessPhoneID = businessPhoneID;
			this.BusinessID = businessID;
			this.PhoneID = phoneID;
			this.IsPrimary = isPrimary;
			this.Business = business;
			this.Phone = phone;
        }
    }
}
