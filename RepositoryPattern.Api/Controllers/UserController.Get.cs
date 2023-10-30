using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Api.Controllers
{
    public partial class UserController
    {
        [HttpGet("users/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var result = await _userService.GetAsync(id);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(ex);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
