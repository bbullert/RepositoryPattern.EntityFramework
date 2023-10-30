using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Api.Controllers
{
    public partial class UserController
    {
        [HttpPut("users/bulk")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutBulkAsync([FromBody] UserUpdateBulk model)
        {
            try
            {
                await _userService.PutBulkAsync(_userService.PatchBulkMockData().Users);
                //await _userService.PatchBulkAsync(model.Users);
                return NoContent();
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
