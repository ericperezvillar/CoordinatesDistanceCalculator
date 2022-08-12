using Application.Wrappers;
using CoreLog.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Helpers
{
    public class ErrorHandler<T>
    {
        private readonly ICoreLogger _coreLogger;

        public ErrorHandler(ICoreLogger coreLogger)
        {
            _coreLogger = coreLogger;
        }

        public UnexpectedResponse<T> LogError(string message, Exception ex, object request, [CallerMemberName] string memberName = "")
        {
            var errorId = _coreLogger.Error(message, ex, memberName, request);
            return new UnexpectedResponse<T>($"ErrorId: {errorId}. {message}", ex);
        }
    }
}
