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
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _UserDetailsService;
        public UserDetailsController(IUserDetailsService UserDetailsService)
        {
            _UserDetailsService = UserDetailsService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDetailsDto>> CreateAsync([FromBody] UserDetailsDto UserDetailsDto)
        {
            Ensure.Any.IsNotNull(UserDetailsDto, nameof(UserDetailsDto));
            var asset = await _UserDetailsService.AddAsync(UserDetailsDto);
            return Created(Endpoints.UserDetails, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UserDetailsDto UserDetailsDto)
        {
            Ensure.Any.IsNotNull(UserDetailsDto, nameof(UserDetailsDto));
            await _UserDetailsService.UpdateAsync(UserDetailsDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var UserDetailsDto = await _UserDetailsService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(UserDetailsDto, nameof(UserDetailsDto));
            await _UserDetailsService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<UserDetailsDto> GetByIdAsync(Guid id)
            => await _UserDetailsService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<UserDetailsDto>> GetAsync()
            => await _UserDetailsService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<UserDetailsDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _UserDetailsService.PagedQueryAsync(name, page, limit);*/
    }
}
