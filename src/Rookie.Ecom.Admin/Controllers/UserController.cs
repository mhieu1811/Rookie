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
    public class UserController : Controller
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody] UserDto UserDto)
        {
            Ensure.Any.IsNotNull(UserDto, nameof(UserDto));
            var asset = await _UserService.AddAsync(UserDto);
            return Created(Endpoints.User, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UserDto UserDto)
        {
            Ensure.Any.IsNotNull(UserDto, nameof(UserDto));
            await _UserService.UpdateAsync(UserDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var UserDto = await _UserService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(UserDto, nameof(UserDto));
            await _UserService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetByIdAsync(Guid id)
            => await _UserService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
            => await _UserService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<UserDto>>
            FindAsync( int page = 1, int limit = 10)
            => await _UserService.PagedQueryAsync( page, limit);
    }
}
