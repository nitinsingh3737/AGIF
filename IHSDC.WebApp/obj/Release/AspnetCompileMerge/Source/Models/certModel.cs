using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHSDC.WebApp.Models
{
    public class certModel
    {
        [Key]
        public int certId { get; set; }
        public string certType { get; set; }
        public string year { get; set; }




    }
}