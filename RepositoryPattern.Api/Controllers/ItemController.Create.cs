﻿using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Dto;

namespace RepositoryPattern.Api.Controllers
{
    public partial class ItemController
    {
        [HttpPost("items")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] ItemCreate model)
        {
            try
            {
                var result = await _itemService.CreateAsync(model);
                return Created(result);
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
