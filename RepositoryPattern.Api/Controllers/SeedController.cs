using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Seed.Services;

namespace RepositoryPattern.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class SeedController : ApiController
    {
        private readonly DataInitializeService _dataInitializeService;

        public SeedController(
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            DataInitializeService dataInitializeService)
            : base(hostingEnvironment)
        {
            _dataInitializeService = dataInitializeService;
        }
    }
}
