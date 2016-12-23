using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class PollOptionViewModel
    {
        public Poll Poll { get; set; }
        public PollOption PollOption { get; set; }
        public string selected { get; set; }
    }
}