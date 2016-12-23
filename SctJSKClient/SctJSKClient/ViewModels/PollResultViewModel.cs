using DTOModel;
using SctJSKClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class PollResultViewModel
    {
        public PollResultViewModel()
        {
            Results = new List<Result>();
        }

        public List<Result> Results;
        public Poll Poll { get; set; }
    }
}