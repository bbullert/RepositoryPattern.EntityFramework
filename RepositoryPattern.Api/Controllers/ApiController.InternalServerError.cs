using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ApiController : ControllerBase
    {
        protected virtual ObjectResult InternalServerError(Exception ex)
        {
            string message = _webHostEnvironment.IsDevelopment() ? 
                ex.Message : "An unexpected error has occurred";
            return StatusCode((int)HttpStatusCode.InternalServerError, message);
        }
    }
}
