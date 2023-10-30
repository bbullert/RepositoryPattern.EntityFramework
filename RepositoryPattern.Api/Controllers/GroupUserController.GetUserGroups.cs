using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Api.Controllers
{
    public partial class GroupUserController
    {
        [HttpGet("users/{userId}/groups")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserGroupsAsync(Guid userId)
        {
            try
            {
                var result = await _groupUserService.GetUserGroupsAsync(userId);
                return Ok(result);
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
