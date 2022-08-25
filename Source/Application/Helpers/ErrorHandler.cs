using Application.Interfaces;
using Application.Wrappers;
using CoreLog.Interfaces;
using System;

namespace Application.Helpers
{
    public class ErrorHandler<T> 
    {
        private readonly ICoreLogger _coreLogger;

        public ErrorHandler(ICoreLogger coreLogger)
        {
            _coreLogger = coreLogger;
        }

        public UnexpectedResponse<T> LogError(string message, Exception ex, object request)
        {
            var errorId = _coreLogger.Error(message, ex, request);
            return new UnexpectedResponse<T>($"ErrorId: {errorId}. {message}", ex);
        }
    }
}
