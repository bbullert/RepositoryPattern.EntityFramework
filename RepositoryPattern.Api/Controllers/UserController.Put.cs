using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Api.Controllers
{
    //public partial class UserController
    //{
    //    [HttpPut("users/{id?}")]
    //    [ProducesResponseType(StatusCodes.Status204NoContent)]
    //    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    //    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //    public async Task<IActionResult> PutAsync([FromRoute] Guid? id, [FromBody] UserUpdate model)
    //    {
    //        try
    //        {
    //            await _userService.PutAsync(id, model);
    //            return NoContent();
    //        }
    //        catch (HttpRequestException ex)
    //        {
    //            return ClientError(ex);
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError(ex);
    //        }
    //    }
    //}
    public partial class UserController
    {
        [HttpPut("users/{id?}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UserCreate model)
        {
            try
            {
                await _userService.PutAsync(id, model);
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
