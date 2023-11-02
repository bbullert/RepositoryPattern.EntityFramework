using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Api.Extnesions;
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Api.Controllers
{
    public partial class UserController
    {
        [HttpPatch("users/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchAsync(Guid id, [FromBody] JsonPatchDocument<UserUpdate> model)
        {
            try
            {
                var validationResults = await _userService.PatchAsync(id, model);
                ModelState.AddValidationResults(validationResults);
                
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

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
