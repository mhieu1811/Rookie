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
    public class OrderController : Controller
    {
        private readonly IOrderService _OrderService;
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateAsync([FromBody] OrderDto OrderDto)
        {
            Ensure.Any.IsNotNull(OrderDto, nameof(OrderDto));
            var asset = await _OrderService.AddAsync(OrderDto);
            return Created(Endpoints.Order, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderDto OrderDto)
        {
            Ensure.Any.IsNotNull(OrderDto, nameof(OrderDto));
            await _OrderService.UpdateAsync(OrderDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var OrderDto = await _OrderService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(OrderDto, nameof(OrderDto));
            await _OrderService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetByIdAsync(Guid id)
            => await _OrderService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetAsync()
            => await _OrderService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<OrderDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _OrderService.PagedQueryAsync(name, page, limit);*/
    }
}
