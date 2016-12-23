using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.Models
{
    public class Result
    {
        public string PollOption { get; set; }
        public double VotePercent { get; set; }
        public int votes { get; set; }
        public int totalvotes { get; set; }

    }
}