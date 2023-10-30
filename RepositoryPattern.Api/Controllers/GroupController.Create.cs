using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Api.Controllers
{
    public partial class GroupController
    {
        [HttpPost("groups")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] GroupCreate model)
        {
            try
            {
                var result = await _groupService.CreateAsync(model);
                return Created(result);
            }
            catch (HttpRequestException ex)
            {
                return ClientError(ex);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
