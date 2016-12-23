using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SctJSKClient.Models
{
    public class OrderDate
    {
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Bestillings dato")]
        public string orderdate { get; set; }

        public string week { get; set; }
        public string day { get; set; }

    }
}