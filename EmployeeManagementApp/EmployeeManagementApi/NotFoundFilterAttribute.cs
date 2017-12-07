using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace EmployeeManagement.Database
{
    public class NotFoundFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext errorContext)
        {
            if (errorContext.Exception is NullReferenceException)
            {
                errorContext.Response = errorContext.Request.CreateResponse(HttpStatusCode.NotFound, "Selection Not Found");
            }
        }
    }
}