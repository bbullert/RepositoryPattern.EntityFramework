using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Seed.Services;

namespace RepositoryPattern.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class SeedController : ApiController
    {
        private readonly ISeedService _seedService;

        public SeedController(
            IWebHostEnvironment webHostEnvironment,
            ISeedService seedService)
            : base(webHostEnvironment)
        {
            _seedService = seedService;
        }
    }
}
