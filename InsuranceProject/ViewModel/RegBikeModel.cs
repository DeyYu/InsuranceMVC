using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.ViewModel
{
    public class RegBikeModel
    {
        [Key]
        public int MotorId { get; set; }
        [Required (ErrorMessage = "Please state person or business")]
        public string ModeOfUse { get; set; }
        [Required(ErrorMessage = "Please enter the vehicle registration number")]
        public string MotorRegPlate { get; set; }
        [Required(ErrorMessage = "Please enter bike value")]
        public int MotorValue { get; set; }
        public Nullable<int> ClientId { get; set; }
    }
}