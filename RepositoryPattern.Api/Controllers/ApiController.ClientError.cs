using Chat.Core.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ApiController : ControllerBase
    {
        //protected virtual ObjectResult Error(HttpRequestException ex)
        //{
        //    var response = new ApiResponse<object>()
        //    {
        //        Status = (int)ex.StatusCode,
        //        Details = ex.Message
        //    };

        //    return StatusCode(response.Status, response);
        //}

        //protected virtual BadRequestObjectResult BadRequest(string message = "Bad request")
        //{
        //    var response = new ApiResponse<object>()
        //    {
        //        Status = (int)HttpStatusCode.BadRequest,
        //        Details = message
        //    };

        //    return base.BadRequest(response);
        //}

        //protected virtual NotFoundObjectResult NotFound(string message = "Not found")
        //{
        //    var response = new ApiResponse<object>()
        //    {
        //        Status = (int)HttpStatusCode.NotFound,
        //        Details = message
        //    };

        //    return base.NotFound(response);
        //}

        //protected new virtual UnprocessableEntityObjectResult UnprocessableEntity(ModelStateDictionary modelState)
        //{
        //    var result = new ValidationResult();
        //    foreach (var key in modelState.Keys)
        //    {
        //        result.AddError(new ValidationError()
        //        {
        //            Name = key,
        //            Messages = modelState[key].Errors.Select(e => e.ErrorMessage)
        //        });
        //    }

        //    return UnprocessableEntity(result);
        //}

        //protected virtual UnprocessableEntityObjectResult UnprocessableEntity(ValidationResult result)
        //{
        //    var response = new ApiResponse<ValidationResult>()
        //    {
        //        Result = result,
        //        Status = (int)HttpStatusCode.UnprocessableEntity,
        //        Details = "Validation failed"
        //    };

        //    return base.UnprocessableEntity(response);
        //}

        //protected new virtual UnprocessableEntityObjectResult UnprocessableEntity(ModelStateDictionary modelState)
        //{
        //    var result = new ValidationResult();
        //    foreach (var key in modelState.Keys)
        //    {
        //        result.AddError(new ValidationError()
        //        {
        //            Name = key,
        //            Messages = modelState[key].Errors.Select(e => e.ErrorMessage)
        //        });
        //    }

        //    return base.UnprocessableEntity(result);
        //}

        protected virtual ObjectResult ClientError(HttpRequestException ex)
        {
            var statusCode = ex.StatusCode ?? HttpStatusCode.BadRequest;
            return StatusCode((int)statusCode, ex.Message);
        }
    }
}
