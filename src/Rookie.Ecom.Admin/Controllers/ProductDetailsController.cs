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
    public class ProductDetailsController : Controller
    {
        private readonly IProductDetailsService _ProductDetailsService;
        public ProductDetailsController(IProductDetailsService ProductDetailsService)
        {
            _ProductDetailsService = ProductDetailsService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDetailsDto>> CreateAsync([FromBody] ProductDetailsDto ProductDetailsDto)
        {
            Ensure.Any.IsNotNull(ProductDetailsDto, nameof(ProductDetailsDto));
            var asset = await _ProductDetailsService.AddAsync(ProductDetailsDto);
            return Created(Endpoints.ProductDetails, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDetailsDto ProductDetailsDto)
        {
            Ensure.Any.IsNotNull(ProductDetailsDto, nameof(ProductDetailsDto));
            await _ProductDetailsService.UpdateAsync(ProductDetailsDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var ProductDetailsDto = await _ProductDetailsService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(ProductDetailsDto, nameof(ProductDetailsDto));
            await _ProductDetailsService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductDetailsDto> GetByIdAsync(Guid id)
            => await _ProductDetailsService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductDetailsDto>> GetAsync()
            => await _ProductDetailsService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<ProductDetailsDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _ProductDetailsService.PagedQueryAsync(name, page, limit);*/
    }
}
