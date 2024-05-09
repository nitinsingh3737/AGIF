using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHSDC.WebApp.Models
{
    public class tbl_LoanFrequency
    {
        [Key]
        public int Id  { get; set; }
        public string Frequency { get; set; }
        //public int VehicleType  { get; set; }
    }
    
}