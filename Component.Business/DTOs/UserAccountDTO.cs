/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:33
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
    public partial class UserAccountDTO
    {
        [DataMember()]
        public Int32 UserAccountID { get; set; }

        [DataMember()]
        public Int32 UserID { get; set; }

        [DataMember()]
        public String UserName { get; set; }

        [DataMember()]
        public Byte[] Password { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        [DataMember()]
        public Nullable<Int32> insuser { get; set; }

        [DataMember()]
        public Nullable<DateTime> insdt { get; set; }

        [DataMember()]
        public Nullable<Int32> upduser { get; set; }

        [DataMember()]
        public Nullable<DateTime> upddt { get; set; }

        [DataMember()]
        public UserDTO User { get; set; }

        public UserAccountDTO()
        {
        }

        public UserAccountDTO(Int32 userAccountID, Int32 userID, String userName, Byte[] password, Boolean isActive, Boolean isDeleted, Nullable<Int32> insuser, Nullable<DateTime> insdt, Nullable<Int32> upduser, Nullable<DateTime> upddt, UserDTO user)
        {
			this.UserAccountID = userAccountID;
			this.UserID = userID;
			this.UserName = userName;
			this.Password = password;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
			this.insuser = insuser;
			this.insdt = insdt;
			this.upduser = upduser;
			this.upddt = upddt;
			this.User = user;
        }
    }
}
