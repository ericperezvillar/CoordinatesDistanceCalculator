using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLog.Interfaces
{
    public interface ICoreLogger
    {
        /// <summary>
        /// Log Information
        /// </summary>
        /// <param name="message">message to log</param>
        void Info(string message);

        /// <summary>
        /// Log error with parameters
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="ex">Exception</param>
        /// <param name="caller">ClassName + MethodName</param>
        /// <param name="request">JsonRequest formatted as string</param>
        /// <returns></returns>
        Guid Error(string message, Exception ex, string caller, object request);

        void Warning(string message, string caller, object request);
    }
}
