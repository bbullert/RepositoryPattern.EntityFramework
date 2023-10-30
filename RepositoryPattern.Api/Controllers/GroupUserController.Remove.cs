using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Api.Controllers
{
    public partial class GroupUserController
    {
        [HttpDelete("groups/{groupId}/users/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveAsync(Guid groupId, Guid userId)
        {
            try
            {
                await _groupUserService.RemoveUserFromGroupAsync(groupId, userId);
                return NoContent();
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