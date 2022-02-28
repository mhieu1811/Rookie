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
    public class ProductPictureController : Controller
    {
        private readonly IProductPictureService _ProductPictureService;
        public ProductPictureController(IProductPictureService ProductPictureService)
        {
            _ProductPictureService = ProductPictureService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductPictureDto>> CreateAsync([FromBody] ProductPictureDto ProductPictureDto)
        {
            Ensure.Any.IsNotNull(ProductPictureDto, nameof(ProductPictureDto));
            var asset = await _ProductPictureService.AddAsync(ProductPictureDto);
            return Created(Endpoints.ProductPicture, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductPictureDto ProductPictureDto)
        {
            Ensure.Any.IsNotNull(ProductPictureDto, nameof(ProductPictureDto));
            await _ProductPictureService.UpdateAsync(ProductPictureDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var ProductPictureDto = await _ProductPictureService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(ProductPictureDto, nameof(ProductPictureDto));
            await _ProductPictureService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductPictureDto> GetByIdAsync(Guid id)
            => await _ProductPictureService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductPictureDto>> GetAsync()
            => await _ProductPictureService.GetAllAsync();

        /*[HttpGet("find")]
        public async Task<PagedResponseModel<ProductPictureDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _ProductPictureService.PagedQueryAsync(name, page, limit);*/
    }
}
