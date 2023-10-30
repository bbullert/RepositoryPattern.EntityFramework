using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ApiController : ControllerBase
    {
        protected virtual ObjectResult Created(object data)
        {
            return StatusCode((int)HttpStatusCode.Created, data);
        }
    }
}
