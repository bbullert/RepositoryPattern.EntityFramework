﻿using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ItemController
    {
        [HttpPut("items/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ItemUpdate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                await _itemService.PutAsync(id, model);
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
