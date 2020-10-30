using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.ViewModel
{
    public class RegCarModel
    {
        [Key]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Please state person or business")]
        public string ModeOfUse { get; set; }
        [Required(ErrorMessage = "Please enter the vehicle registration number")]
        public string RegPlate { get; set; }
        [Required(ErrorMessage = "Please enter car value")]
        public int CarValue { get; set; }
        public Nullable<int> ClientId { get; set; }
    }
}