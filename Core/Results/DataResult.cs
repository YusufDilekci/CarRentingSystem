using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, string message, bool succesed) : base(message, succesed) 
        {
            Data= data;
        }


        public DataResult(T data, bool succesed) : base(succesed)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
