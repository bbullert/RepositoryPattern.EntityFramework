using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Api.Controllers
{
    public partial class UserController
    {
        [HttpPost("users/bulk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBulkAsync([FromBody] UserCreateBulk model)
        {
            try
            {
                var result = await _userService.CreateBulkAsync(model.Users);
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
