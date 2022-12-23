using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class Result : IResult
    {
        public Result(string message, bool successed) : this(successed)
        {
            Message= message;
            
        }

        public Result(bool successed)
        {
            Successed = successed;
        }

        public string Message { get;}
        public bool Successed { get; }

    }
}
