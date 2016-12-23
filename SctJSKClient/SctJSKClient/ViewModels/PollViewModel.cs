using DTOModel;
using SctJSKClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SctJSKClient.ViewModels
{
    public class PollViewModel
    {

        public PollViewModel()
        {
            Polls = new List<Poll>();
            options = new List<PollOption>();
        }

        public IEnumerable<Poll> Polls { get; set; }
        public IEnumerable<PollOption> options { get; set; }
        public Poll Poll { get; set; }
    }
}