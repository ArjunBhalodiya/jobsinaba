//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobsInABA.Component.AddressBook.ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phone
    {
        public Phone()
        {
            this.BusinessPhones = new HashSet<BusinessPhone>();
            this.UserPhones = new HashSet<UserPhone>();
        }
    
        public int PhoneID { get; set; }
        public int AddressbookID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string Number { get; set; }
        public string Ext { get; set; }
        public Nullable<int> PhoneTypeID { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual ICollection<BusinessPhone> BusinessPhones { get; set; }
        public virtual TypeCode TypeCode { get; set; }
        public virtual ICollection<UserPhone> UserPhones { get; set; }
    }
}
