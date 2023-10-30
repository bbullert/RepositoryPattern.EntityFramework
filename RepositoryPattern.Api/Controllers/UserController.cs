using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Services;

namespace RepositoryPattern.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            IUserService userService)
            : base(hostingEnvironment)
        {
            _userService = userService;
        }
    }
}
