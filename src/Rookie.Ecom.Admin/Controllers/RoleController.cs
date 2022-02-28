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
    public class RoleController : Controller
    {
        private readonly IRoleService _RoleService;
        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> CreateAsync([FromBody] RoleDto RoleDto)
        {
            Ensure.Any.IsNotNull(RoleDto, nameof(RoleDto));
            var asset = await _RoleService.AddAsync(RoleDto);
            return Created(Endpoints.Role, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] RoleDto RoleDto)
        {
            Ensure.Any.IsNotNull(RoleDto, nameof(RoleDto));
            await _RoleService.UpdateAsync(RoleDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var RoleDto = await _RoleService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(RoleDto, nameof(RoleDto));
            await _RoleService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<RoleDto> GetByIdAsync(Guid id)
            => await _RoleService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<RoleDto>> GetAsync()
            => await _RoleService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<RoleDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _RoleService.PagedQueryAsync(name, page, limit);
    }
}
