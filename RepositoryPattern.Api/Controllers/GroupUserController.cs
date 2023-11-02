using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Services;

namespace RepositoryPattern.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class GroupUserController : ApiController
    {
        private readonly IGroupUserService _groupUserService;

        public GroupUserController(
            IWebHostEnvironment webHostEnvironment,
            IGroupUserService groupUserService)
            : base(webHostEnvironment)
        {
            _groupUserService = groupUserService;
        }
    }
}
