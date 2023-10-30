using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ApiController : ControllerBase
    {
        protected virtual ObjectResult StatusCode(HttpRequestException ex)
        {
            var statusCode = ex.StatusCode ?? HttpStatusCode.BadRequest;
            return StatusCode((int)statusCode, ex.Message);
        }
    }
}
