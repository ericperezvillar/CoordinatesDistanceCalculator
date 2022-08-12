using CoreLog.Interfaces;
using Serilog;
using System;

namespace CoreLog.Logger
{
    public class Logger : ICoreLogger
    {
        public Guid Error(string message, Exception ex, string caller, object request)
        {
            var errorId = Guid.NewGuid();
            Log.Logger.ForContext("Exception", ex, destructureObjects: true)
                .ForContext("Caller", caller)
                .Error(ex, message, errorId, ex.Message, request);
            return errorId;
        }

        public void Info(string message)
        {
            Log.Logger.Information(message);
        }

        public void Warning(string message, string caller, object request)
        {
            Log.Logger.ForContext("Exception", null)
                .ForContext("Caller", caller)
                .Warning(message);
        }
    }
}
