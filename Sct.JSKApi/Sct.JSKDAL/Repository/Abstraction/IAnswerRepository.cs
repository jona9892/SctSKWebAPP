using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sct.JSKDAL.Repository.Absttraction
{
    public interface IAnswerRepository
    {
        Answer Add(Answer answer);
        List<Answer> ReadAllByUser(int userid);
        List<PollResult> ReadResults(int pollid);
    }
}
