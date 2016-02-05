/*
Project: Jobs In ABA
Authoer: Ghanshyam Bhalala
Date Created: 2015-12-04

*/
//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/01/01 - 02:55:15
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
    public partial class BusinessEmailDTO
    {
        [DataMember()]
        public Int32 BusinessEmailID { get; set; }

        [DataMember()]
        public Int32 BusinessID { get; set; }

        [DataMember()]
        public Int32 EmailID { get; set; }

        [DataMember()]
        public Boolean IsPrimary { get; set; }

        [DataMember()]
        public BusinessDTO Business { get; set; }

        [DataMember()]
        public EmailDTO Email { get; set; }

        public BusinessEmailDTO()
        {
        }

        public BusinessEmailDTO(Int32 businessEmailID, Int32 businessID, Int32 emailID, Boolean isPrimary, BusinessDTO business, EmailDTO email)
        {
			this.BusinessEmailID = businessEmailID;
			this.BusinessID = businessID;
			this.EmailID = emailID;
			this.IsPrimary = isPrimary;
			this.Business = business;
			this.Email = email;
        }
    }
}