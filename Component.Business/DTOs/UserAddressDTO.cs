/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:35
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
    public partial class UserAddressDTO
    {
        [DataMember()]
        public Int32 UserAddressID { get; set; }

        [DataMember()]
        public Int32 UserID { get; set; }

        [DataMember()]
        public Int32 AddressID { get; set; }

        [DataMember()]
        public Boolean IsPrimary { get; set; }

        [DataMember()]
        public AddressDTO Address { get; set; }

        [DataMember()]
        public UserDTO User { get; set; }

        public UserAddressDTO()
        {
        }

        public UserAddressDTO(Int32 userAddressID, Int32 userID, Int32 addressID, Boolean isPrimary, AddressDTO address, UserDTO user)
        {
			this.UserAddressID = userAddressID;
			this.UserID = userID;
			this.AddressID = addressID;
			this.IsPrimary = isPrimary;
			this.Address = address;
			this.User = user;
        }
    }
}
