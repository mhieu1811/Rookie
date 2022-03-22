using EnsureThat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;


namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IStorageService _storageService;

        public CategoryController(ICategoryService categoryService, IStorageService storageService)
        {
            _categoryService = categoryService;
            _storageService = storageService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateAsync([FromForm] CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            categoryDto.CategoryPicture = await this.SaveFile(categoryDto.Picture);
            var asset = await _categoryService.AddAsync(categoryDto);

            return Created(Endpoints.Category, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromForm] CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            if(categoryDto.Picture != null)
            {
                categoryDto.CategoryPicture = await this.SaveFile(categoryDto.Picture);
            }    
            await _categoryService.UpdateAsync(categoryDto);

            return NoContent();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
       /* public async Task RemoveImages(string fileName)
        {
            await _storageService.DeleteFileAsync(fileName);
        }*/
        /*
                [HttpDelete("{id}")]
                public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
                {
                    var categoryDto = await _categoryService.GetByIdAsync(id);
                    Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
                    await _categoryService.DeleteAsync(id);
                    return NoContent();
                }*/

        [HttpGet("{id}")]
        public async Task<CategoryDto> GetByIdAsync(Guid id)
            => await _categoryService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAsync()
            => await _categoryService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<CategoryDto>>
            FindAsync(string? name, int page = 1, int limit = 10)
            => await _categoryService.PagedQueryAsync(name, page, limit);
    }
}
