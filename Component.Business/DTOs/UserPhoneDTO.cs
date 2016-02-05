/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:37
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
    public partial class UserPhoneDTO
    {
        [DataMember()]
        public Int32 UserPhoneID { get; set; }

        [DataMember()]
        public Int32 UserID { get; set; }

        [DataMember()]
        public Int32 PhoneID { get; set; }

        [DataMember()]
        public Boolean IsPrimary { get; set; }

        [DataMember()]
        public UserDTO User { get; set; }

        [DataMember()]
        public PhoneDTO Phone { get; set; }

        public UserPhoneDTO()
        {
        }

        public UserPhoneDTO(Int32 userPhoneID, Int32 userID, Int32 phoneID, Boolean isPrimary, UserDTO user, PhoneDTO phone)
        {
			this.UserPhoneID = userPhoneID;
			this.UserID = userID;
			this.PhoneID = phoneID;
			this.IsPrimary = isPrimary;
			this.User = user;
			this.Phone = phone;
        }
    }
}