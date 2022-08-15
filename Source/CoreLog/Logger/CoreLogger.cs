using CoreLog.Interfaces;
using Serilog;
using System;

namespace CoreLog.Logger
{
    public class CoreLogger : ICoreLogger
    {
        public Guid Error(string message, Exception ex, object request)
        {
            var errorId = Guid.NewGuid();
            Log.Logger.ForContext("Exception", ex, destructureObjects: true)
                .Error(ex, message, errorId, ex.Message, request);
            return errorId;
        }

        public void Info(string message)
        {
            Log.Logger.Information(message);
        }

        public void Warning(string message)
        {
            Log.Logger.ForContext("Exception", null)
                .Warning(message);
        }
    }
}
