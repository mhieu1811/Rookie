using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class ListProductModel : PageModel
    {
        private readonly IProductService _productService;
        public ListProductModel( IProductService productService)
        {

            _productService = productService;

        }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 4;
        public PagedResponseModel<ProductDto> ListProduct { get; set; }
        public async Task OnGet()
        {
            ListProduct = await _productService.PagedQueryAsync(null,CurrentPage, PageSize,null);
        }
    }
}
