using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.ViewModel
{
    public class ClaimModel
    {
        [Key]
        public int ClaimId { get; set; }
        public string Nature { get; set; }
        public string Location { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> ClientId { get; set; }
        public string LicensePlate { get; set; }
    }
}