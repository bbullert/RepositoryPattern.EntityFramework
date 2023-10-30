using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Api.Controllers
{
    public partial class GroupController
    {
        [HttpGet("groups")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRangeAsync()
        {
            try
            {
                var result = await _groupService.GetListAsync();
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
