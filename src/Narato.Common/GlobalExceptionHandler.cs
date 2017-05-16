using Narato.Common.Exceptions;
using Narato.Common.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Narato.Common
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private Exception GetCorrectException(Exception exception)
        {
            // Exception was thrown in an async task, which was Resulted. Those are wrapped in an AggregateException
            if (exception is AggregateException && exception.InnerException != null)
            {
                return exception.InnerException;
            }
            return exception;
        }

        protected override HttpResponseMessage CreateResponse(Exception exception, HttpRequestMessage request)
        {
            if (exception is ArgumentNullException)
            {
                var response = request.CreateResponse(HttpStatusCode.BadRequest, new ErrorContent { Code = string.Empty, Message = exception.Message });
                response.ReasonPhrase = "Argument Null";
                return response;
            }
            if (exception is ModelValidationException)
            {
                var validationException = exception as ModelValidationException;
                return request.CreateResponse(HttpStatusCode.BadRequest, new ValidationErrorContent<string> { ValidationMessages = validationException.ValidationMessages });
            }
            if (exception is EntityNotFoundException)
            {
                var codedException = exception as CodedException;
                return request.CreateResponse(HttpStatusCode.NotFound, new ErrorContent { Code = codedException.ErrorCode, Message = codedException.Message });
                //context.Result = new NotFoundResult(request);
            }
            if (exception is ForbiddenException)
            {
                var codedException = exception as CodedException;
                return request.CreateResponse(HttpStatusCode.Forbidden, new ErrorContent { Code = codedException.ErrorCode, Message = codedException.Message });
            }
            return null;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            var exceptionContext = context.ExceptionContext;
            if (exceptionContext == null)
            {
                return;
            }
            var exception = GetCorrectException(exceptionContext.Exception);
            if (exception == null)
            {
                return;
            }
            var request = exceptionContext.Request;
            if (request == null)
            {
                return;
            }

            var response = CreateResponse(exception, request);
            if (response != null)
            {
                context.Result = new RawResult(request, response);
            }
            else
            {
                // Handle other exceptions, do other things
                context.Result = new InternalServerErrorResult(request);
            }
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            var isTopLevel = base.ShouldHandle(context);
            return true;
        }
    }

    public class RawResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _response;

        public RawResult(HttpRequestMessage request, HttpResponseMessage response)
        {
            _request = request;
            _response = response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }
}
