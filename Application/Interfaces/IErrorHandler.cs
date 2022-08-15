using Application.Wrappers;
using System;
using System.Runtime.CompilerServices;

namespace Application.Interfaces
{
    public interface IErrorHandler<T>
    {
        UnexpectedResponse<T> LogError(string message, Exception ex, object request, [CallerMemberName] string memberName = "");
    }
}