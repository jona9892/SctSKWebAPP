﻿using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService.Services.Abstraction
{
    public interface IAnswerService<Answer>
    {
        HttpResponseMessage Add(Answer answer);
        IEnumerable<Poll> GetAllUnAnsweredPolls(int userid);
        IEnumerable<PollResult> ReadResults(int pollid);
    }
}
