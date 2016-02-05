/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:38
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
    public partial class UserRoleDTO
    {
        [DataMember()]
        public Int32 UserRoleID { get; set; }

        [DataMember()]
        public Int32 UserID { get; set; }

        [DataMember()]
        public Int32 RoleID { get; set; }

        [DataMember()]
        public RoleDTO Role { get; set; }

        [DataMember()]
        public UserDTO User { get; set; }

        public UserRoleDTO()
        {
        }

        public UserRoleDTO(Int32 userRoleID, Int32 userID, Int32 roleID, RoleDTO role, UserDTO user)
        {
			this.UserRoleID = userRoleID;
			this.UserID = userID;
			this.RoleID = roleID;
			this.Role = role;
			this.User = user;
        }
    }
}