/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:27
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
    public partial class RoleDTO
    {
        [DataMember()]
        public Int32 RoleID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public Int32 Precedence { get; set; }

        [DataMember()]
        public List<UserRoleDTO> UserRoles { get; set; }

        public RoleDTO()
        {
        }

        public RoleDTO(Int32 roleID, String name, Int32 precedence, List<UserRoleDTO> userRoles)
        {
			this.RoleID = roleID;
			this.Name = name;
			this.Precedence = precedence;
			this.UserRoles = userRoles;
        }
    }
}
