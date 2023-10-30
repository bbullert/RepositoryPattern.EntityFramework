using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ApiController : ControllerBase
    {
        protected readonly IHostingEnvironment _hostingEnvironment;
        
        public ApiController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
    }
}
