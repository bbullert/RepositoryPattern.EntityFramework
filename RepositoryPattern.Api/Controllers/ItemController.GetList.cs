using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ItemController
    {
        [HttpGet("items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRangeAsync()
        {
            try
            {
                var result = await _itemService.GetListAsync();
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
