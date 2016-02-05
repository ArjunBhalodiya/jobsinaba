/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:29
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
    public partial class TypeCodeDTO
    {
        [DataMember()]
        public Int32 TypeCodeID { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public String Code { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Int32 ClassTypeID { get; set; }

        [DataMember()]
        public Nullable<Int32> ParentTypeCodeID { get; set; }

        [DataMember()]
        public List<AddressDTO> Addresses { get; set; }

        [DataMember()]
        public List<BusinessDTO> Businesses { get; set; }

        [DataMember()]
        public List<BusinessUserMapDTO> BusinessUserMaps { get; set; }

        [DataMember()]
        public ClassTypeDTO ClassType { get; set; }

        [DataMember()]
        public List<EmailDTO> Emails { get; set; }

        [DataMember()]
        public List<JobApplicationStateDTO> JobApplicationStates { get; set; }

        [DataMember()]
        public List<JobDTO> Jobs { get; set; }

        [DataMember()]
        public List<TypeCodeDTO> TypeCodes1 { get; set; }

        [DataMember()]
        public TypeCodeDTO TypeCode1 { get; set; }

        [DataMember()]
        public List<PhoneDTO> Phones { get; set; }

        public TypeCodeDTO()
        {
        }

        public TypeCodeDTO(Int32 typeCodeID, String name, String code, String description, Int32 classTypeID, Nullable<Int32> parentTypeCodeID, List<AddressDTO> addresses, List<BusinessDTO> businesses, List<BusinessUserMapDTO> businessUserMaps, ClassTypeDTO classType, List<EmailDTO> emails, List<JobApplicationStateDTO> jobApplicationStates, List<JobDTO> jobs, List<TypeCodeDTO> typeCodes1, TypeCodeDTO typeCode1, List<PhoneDTO> phones)
        {
			this.TypeCodeID = typeCodeID;
			this.Name = name;
			this.Code = code;
			this.Description = description;
			this.ClassTypeID = classTypeID;
			this.ParentTypeCodeID = parentTypeCodeID;
			this.Addresses = addresses;
			this.Businesses = businesses;
			this.BusinessUserMaps = businessUserMaps;
			this.ClassType = classType;
			this.Emails = emails;
			this.JobApplicationStates = jobApplicationStates;
			this.Jobs = jobs;
			this.TypeCodes1 = typeCodes1;
			this.TypeCode1 = typeCode1;
			this.Phones = phones;
        }
    }
}
