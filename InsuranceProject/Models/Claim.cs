//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Claim
    {
        public int ClaimId { get; set; }
        public string Nature { get; set; }
        public string Location { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string LicensePlate { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
