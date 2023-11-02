using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ApiController : ControllerBase
    {
        //protected virtual ObjectResult Result(object? data, HttpStatusCode statusCode, string message)
        //{
        //    var response = new ApiResponse<object>()
        //    {
        //        Result = data,
        //        Status = (int)statusCode,
        //        Details = message
        //    };

        //    return StatusCode(response.Status, response);
        //}

        //protected virtual ObjectResult Ok(object? data = null, string message = "OK")
        //{
        //    return Result(data, HttpStatusCode.OK, message);
        //}

        //protected virtual ObjectResult Created(object? data, string message = "Created")
        //{
        //    return Result(data, HttpStatusCode.Created, message);
        //}

        //protected virtual ObjectResult NoContent(object? data = null, string message = "No content")
        //{
        //    return Result(data, HttpStatusCode.NoContent, message);
        //}

        protected virtual ObjectResult Created(object data)
        {
            return StatusCode((int)HttpStatusCode.Created, data);
        }
    }
}
