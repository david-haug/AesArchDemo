using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Aes.Api.Core.Models;
using Aes.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aes.Api.Core.Filters
{
    public class HttpExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.Result = new ObjectResult(new ValidationErrorModel
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Code = 2001,
                    Message = "Validation failed",
                    Errors = ((ValidationException)context.Exception).ValidationErrors

                })
                { StatusCode = (int)HttpStatusCode.BadRequest };
                return;
            }

            if (context.Exception is NotAuthorizedException)
            {
                context.Result = new ObjectResult(new ErrorModel
                    {
                        Status = (int)HttpStatusCode.Forbidden,
                        Code = 2002,
                        Message = "The user does not have the required permissions to access the resource."
                })
                    { StatusCode = (int)HttpStatusCode.Forbidden };
                return;
            }


            if (context.Exception is NotFoundException)
            {
                context.Result = new ObjectResult(new ErrorModel
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Code = 2003,
                    Message = context.Exception.Message
                })
                { StatusCode = (int)HttpStatusCode.NotFound };
                return;
            }

            //if (context.Exception is InternalServerErrorException)
            //{
            //    context.Result = new ObjectResult(new ErrorModel
            //    {
            //        Status = (int)HttpStatusCode.InternalServerError,
            //        Code = 1003,
            //        Message = context.Exception.Message
            //    })
            //    { StatusCode = (int)HttpStatusCode.InternalServerError };
            //}

            //Unhandled
            context.Result = new ObjectResult(new ErrorModel
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Code = 2004,
                //Message = context.Exception.Message
            })
            { StatusCode = (int)HttpStatusCode.InternalServerError };
        }


    }
}
