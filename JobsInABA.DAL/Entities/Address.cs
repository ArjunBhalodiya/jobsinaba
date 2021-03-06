//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobsInABA.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public Address()
        {
            this.BusinessAddresses = new HashSet<BusinessAddress>();
            this.UserAddresses = new HashSet<UserAddress>();
        }
    
        public int AddressID { get; set; }
        public string Title { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> AddressTypeID { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual TypeCode TypeCode { get; set; }
        public virtual ICollection<BusinessAddress> BusinessAddresses { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
