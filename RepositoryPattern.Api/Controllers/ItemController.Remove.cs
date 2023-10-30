using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ItemController
    {
        [HttpDelete("items/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            try
            {
                await _itemService.RemoveAsync(id);
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
