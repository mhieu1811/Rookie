using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : Controller
    {
        private readonly IRatingService _RatingService;
        public RatingController(IRatingService RatingService)
        {
            _RatingService = RatingService;
        }

        [HttpPost]
        public async Task<ActionResult<RatingDto>> CreateAsync([FromBody] RatingDto RatingDto)
        {
            Ensure.Any.IsNotNull(RatingDto, nameof(RatingDto));
            var asset = await _RatingService.AddAsync(RatingDto);
            return Created(Endpoints.Rating, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RatingDto RatingDto)
        {
            Ensure.Any.IsNotNull(RatingDto, nameof(RatingDto));
            await _RatingService.UpdateAsync(RatingDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var RatingDto = await _RatingService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(RatingDto, nameof(RatingDto));
            await _RatingService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<RatingDto> GetByIdAsync(Guid id)
            => await _RatingService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<RatingDto>> GetAsync()
            => await _RatingService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<RatingDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _RatingService.PagedQueryAsync(name, page, limit);*/
    }
}
