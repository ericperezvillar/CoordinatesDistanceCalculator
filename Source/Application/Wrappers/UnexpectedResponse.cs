using System;

namespace Application.Wrappers
{
    public class UnexpectedResponse<T> : Response<T>
    {
        public UnexpectedResponse(string message, Exception ex)
        {
            Succeeded = false;
            Messages.Add(message);
            Data = this.Data;
            Exception = ex;
        }
    }
}
