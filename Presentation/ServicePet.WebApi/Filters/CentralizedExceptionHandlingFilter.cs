using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ServicePet.Domain.Exceptions;
using ServicePet.WebApi.Models.Responses;
namespace ServicePet.WebApi.Filters
{
    public class CentralizedExceptionHandlingFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var (message, statusCode) = TryGetUserMessageFromException(context);

            if (message != null && statusCode != 0)
            {
                context.Result = new ObjectResult(new ErrorResponse(message, statusCode))
                {
                    StatusCode = statusCode
                };
                context.ExceptionHandled = true;
            }
        }

        private (string?, int) TryGetUserMessageFromException(ExceptionContext context)
        {
            return context.Exception switch
            {
                PetProfileNotFoundException => ("Питомца с данным профилем не существует.", StatusCodes.Status400BadRequest),
                Exception => ("Неизвестная ошибка.", StatusCodes.Status500InternalServerError),
                _ => (null, 0)
            };
        }
    }
}
