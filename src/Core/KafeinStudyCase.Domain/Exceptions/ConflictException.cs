using KafeinStudyCase.Core.ExceptionHandling.Exceptions.Common;
using KafeinStudyCase.Core.ExceptionHandling.Wrapper;
using System.Net;

namespace KafeinStudyCase.Domain.Exceptions;
public class ConflictException : BaseException
{
    public ConflictException(string message) : base(message, HttpStatusCode.Conflict)
    {
    }

    public ConflictException(string message, string statusCode = null,
        HttpStatusCode resultCode = HttpStatusCode.Conflict) : base(message, statusCode, resultCode)
    {
    }

    public ConflictException(string message, string? statusCode = null,
        IEnumerable<ExceptionErrorResponse>? errors = null, HttpStatusCode resultCode = HttpStatusCode.Conflict)
        : base(message, statusCode, errors, resultCode)
    {
    }
}