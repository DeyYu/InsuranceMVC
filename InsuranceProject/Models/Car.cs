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
    
    public partial class Car
    {
        public int CarId { get; set; }
        public string ModeOfUse { get; set; }
        public string RegPlate { get; set; }
        public int CarValue { get; set; }
        public Nullable<int> ClientId { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
