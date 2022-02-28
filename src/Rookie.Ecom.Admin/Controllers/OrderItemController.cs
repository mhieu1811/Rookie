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
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _OrderItemService;
        public OrderItemController(IOrderItemService OrderItemService)
        {
            _OrderItemService = OrderItemService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> CreateAsync([FromBody] OrderItemDto OrderItemDto)
        {
            Ensure.Any.IsNotNull(OrderItemDto, nameof(OrderItemDto));
            var asset = await _OrderItemService.AddAsync(OrderItemDto);
            return Created(Endpoints.OrderItem, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] OrderItemDto OrderItemDto)
        {
            Ensure.Any.IsNotNull(OrderItemDto, nameof(OrderItemDto));
            await _OrderItemService.UpdateAsync(OrderItemDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var OrderItemDto = await _OrderItemService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(OrderItemDto, nameof(OrderItemDto));
            await _OrderItemService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<OrderItemDto> GetByIdAsync(Guid id)
            => await _OrderItemService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<OrderItemDto>> GetAsync()
            => await _OrderItemService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<OrderItemDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _OrderItemService.PagedQueryAsync(name, page, limit);*/
    }
}
