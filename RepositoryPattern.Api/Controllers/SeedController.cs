using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Seed.Generators;

namespace RepositoryPattern.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class SeedController : ApiController
    {
        private readonly UserGenerator _userGenerator;

        public SeedController(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserGenerator userGenerator)
            : base(hostingEnvironment)
        {
            _userGenerator = userGenerator;
        }
    }
}
