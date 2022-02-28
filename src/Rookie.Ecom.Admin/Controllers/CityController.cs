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
    public class CityController : Controller
    {
        private readonly ICityService _CityService;
        public CityController(ICityService CityService)
        {
            _CityService = CityService;
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateAsync([FromBody] CityDto CityDto)
        {
            Ensure.Any.IsNotNull(CityDto, nameof(CityDto));
            var asset =  _CityService.AddAsync(CityDto);
            return Created(Endpoints.City, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] CityDto CityDto)
        {
            Ensure.Any.IsNotNull(CityDto, nameof(CityDto));
            await _CityService.UpdateAsync(CityDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var CityDto = await _CityService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(CityDto, nameof(CityDto));
            await _CityService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<CityDto> GetByIdAsync(Guid id)
            => await _CityService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<CityDto>> GetAsync()
            => await _CityService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<CityDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _CityService.PagedQueryAsync(name, page, limit);
    }
}
