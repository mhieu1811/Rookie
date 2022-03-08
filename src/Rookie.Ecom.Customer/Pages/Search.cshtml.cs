using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categorytService;

        public SearchModel(IProductService productService, ICategoryService categoryService)
        {

            _productService = productService;
            _categorytService = categoryService;
        }
        public string Keyword { get; set; }
        public string CategoryId { get; set; }
        public string Price { get; set; }
        public PagedResponseModel<ProductDto> ListProduct { get; set; }
        public IEnumerable<CategoryDto> Category { get; set; }

        public async Task OnGet(string keyword,string category)
        {
            ListProduct = await _productService.PagedQueryAsync(keyword, 1, 9, category);
            Category = await _categorytService.GetAllAsync();

            Keyword = keyword;
            CategoryId = category;
        }
    }
}
