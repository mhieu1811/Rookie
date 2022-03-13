using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categorytService;
        private readonly ICartService _cartService;

        public IndexModel(IProductService productService, ICategoryService categoryService, ICartService cartService)
        {

            _productService = productService;
            _categorytService = categoryService;
            _cartService = cartService;
        }
        public string Keyword { get; set; }
        public string CategoryId { get; set; }
        public string Price { get; set; }
        public PagedResponseModel<ProductDto> ListProduct { get; set; }
        public IEnumerable<CategoryDto> Category { get; set; }

        public async Task OnGet()
        {
            ListProduct = await _productService.PagedQueryAsync(null, 1, 8, null);
            Category = await _categorytService.GetListAsync();
        }

        [BindProperty]
        public string pId { get; set; }

        [Authorize]
        public async Task<IActionResult> OnPost(string pId)
        {
            



            ListProduct = await _productService.PagedQueryAsync(null, 1, 8, null);
            Category = await _categorytService.GetListAsync();
            return Page();
        }
    }
}
