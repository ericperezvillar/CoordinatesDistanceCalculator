using System;
using System.Collections.Generic;

namespace Application.Wrappers
{
    public abstract class Response<T>
    {
        public bool Succeeded { get; set; }

        public List<string> Messages { get; protected set; } = new List<string>();

        public Exception Exception { get; protected set; }

        public T Data { get; set; }        
    }
}
