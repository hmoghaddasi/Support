using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Framework.Core.Exception;

namespace Support.Hosts.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext httpActionExecutedContext)
        {
            var exception = httpActionExecutedContext.Exception as BusinessException;
            if (exception == null)
            {
                HandleUnexpectedError(httpActionExecutedContext, exception);
            }
            else
            {
                HandleBusinessError(httpActionExecutedContext, exception);
            }
            base.OnException(httpActionExecutedContext);
        }

        private void HandleUnexpectedError(HttpActionExecutedContext actionExecutedContext, BusinessException exception)
        {
            WriteExceptionIntoLogs(exception);
            CreateUnknownErrorResponse(actionExecutedContext);
        }
        private void WriteExceptionIntoLogs(BusinessException exception)
        {
            //Log exception
        }
        private static void CreateUnknownErrorResponse(HttpActionExecutedContext actionExecutedContext)
        {
            var response = new { Message = "Unknown Error. Please call system adminsitrators." };
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
        }
        private void HandleBusinessError(HttpActionExecutedContext actionExecutedContext, BusinessException exception)
        {
            var response = new { Code = exception.GetCode(), Message = exception.Message };
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }
    }
}