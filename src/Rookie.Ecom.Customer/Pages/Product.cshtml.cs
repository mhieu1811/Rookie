using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductModel : PageModel
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IProductService _productService;
        
        public ProductModel(LinkGenerator linkGenerator, IProductService productService)
        {
            this.linkGenerator = linkGenerator;
            _productService = productService;

        }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public string PathByPage { get; set; }
        public string UriByPage { get; set; }
        public ProductDto Product { get; set; }
        public async Task OnGet()
        {
            Product = await _productService.GetByIdAsync(Guid.Parse(Id));

        }
    }
}
