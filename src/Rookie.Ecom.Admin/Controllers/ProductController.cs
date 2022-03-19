using EnsureThat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;
        private readonly IProductCreateService _ProductCreateService;

        public ProductController(IProductService ProductService, IProductCreateService ProductCreateService)
        {
            _ProductService = ProductService;
            _ProductCreateService = ProductCreateService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductCreateDto>> CreateAsync([FromForm] ProductCreateDto ProductDto)
        {
            Ensure.Any.IsNotNull(ProductDto, nameof(ProductDto));
            var asset = await _ProductCreateService.AddAsync(ProductDto);
            return Created(Endpoints.Product, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromForm] ProductCreateDto ProductDto)
        {
            Ensure.Any.IsNotNull(ProductDto, nameof(ProductDto));
            await _ProductCreateService.UpdateAsync(ProductDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var ProductDto = await _ProductService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(ProductDto, nameof(ProductDto));
            await _ProductService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(Guid id)
            => await _ProductService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAsync()
            => await _ProductService.GetAllAsync();


        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _ProductService.PagedQueryAsync(name, page, limit,null,false);



        
    }
}
