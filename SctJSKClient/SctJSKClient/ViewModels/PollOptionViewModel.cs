using DTOModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class PollOptionViewModel
    {
        public Poll Poll { get; set; }
        public PollOption PollOption { get; set; }
        [Required(ErrorMessage = "Du skal vælge en valgmulighed for at gemme")]
        public string selected { get; set; }
    }
}