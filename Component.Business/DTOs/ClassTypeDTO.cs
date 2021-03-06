/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:18
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
    public partial class ClassTypeDTO
    {
        [DataMember()]
        public Int32 ClassTypeID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public List<TypeCodeDTO> TypeCodes { get; set; }

        public ClassTypeDTO()
        {
        }

        public ClassTypeDTO(Int32 classTypeID, String name, String code, String description, List<TypeCodeDTO> typeCodes)
        {
			this.ClassTypeID = classTypeID;
			this.Name = name;
			this.Code = code;
			this.Description = description;
			this.TypeCodes = typeCodes;
        }
    }
}
