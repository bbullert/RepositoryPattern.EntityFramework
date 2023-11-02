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
            IWebHostEnvironment webHostEnvironment,
            IUserService userService)
            : base(webHostEnvironment)
        {
            _userService = userService;
        }
    }
}
