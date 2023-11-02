using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Services;

namespace RepositoryPattern.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class ItemController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemController(
            IWebHostEnvironment webHostEnvironment,
            IItemService itemService)
            : base(webHostEnvironment)
        {
            _itemService = itemService;
        }
    }
}
