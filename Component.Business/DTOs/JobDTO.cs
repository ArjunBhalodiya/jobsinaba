/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:24
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
    public partial class JobDTO
    {
        [DataMember()]
        public Int32 JobID { get; set; }

        [DataMember()]
        public Int32 BusinessID { get; set; }

        [DataMember()]
        public String Title { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Nullable<Int32> JobTypeID { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        [DataMember()]
        public Nullable<DateTime> StartDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> EndDate { get; set; }

        [DataMember()]
        public Nullable<Int32> insuser { get; set; }

        [DataMember()]
        public Nullable<DateTime> insdt { get; set; }

        [DataMember()]
        public Nullable<Int32> upduser { get; set; }

        [DataMember()]
        public Nullable<DateTime> upddt { get; set; }

        [DataMember()]
        public BusinessDTO Business { get; set; }

        [DataMember()]
        public List<JobApplicationDTO> JobApplications { get; set; }

        [DataMember()]
        public TypeCodeDTO TypeCode { get; set; }

        public JobDTO()
        {
        }

        public JobDTO(Int32 jobID, Int32 businessID, String title, String description, Nullable<Int32> jobTypeID, Boolean isActive, Boolean isDeleted, Nullable<DateTime> startDate, Nullable<DateTime> endDate, Nullable<Int32> insuser, Nullable<DateTime> insdt, Nullable<Int32> upduser, Nullable<DateTime> upddt, BusinessDTO business, List<JobApplicationDTO> jobApplications, TypeCodeDTO typeCode)
        {
			this.JobID = jobID;
			this.BusinessID = businessID;
			this.Title = title;
			this.Description = description;
			this.JobTypeID = jobTypeID;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
			this.StartDate = startDate;
			this.EndDate = endDate;
			this.insuser = insuser;
			this.insdt = insdt;
			this.upduser = upduser;
			this.upddt = upddt;
			this.Business = business;
			this.JobApplications = jobApplications;
			this.TypeCode = typeCode;
        }
    }
}
