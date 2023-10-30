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
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            IGroupUserService groupUserService)
            : base(hostingEnvironment)
        {
            _groupUserService = groupUserService;
        }
    }
}
