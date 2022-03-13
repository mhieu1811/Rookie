using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    public class ProductModel : PageModel
    {
        private readonly LinkGenerator linkGenerator;
        private readonly IProductService _productService;
        private readonly IRatingService _ratingService;
        public ProductModel(LinkGenerator linkGenerator, IProductService productService, IRatingService ratingService)
        {
            this.linkGenerator = linkGenerator;
            _productService = productService;
            _ratingService = ratingService;
        }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public string PathByPage { get; set; }
        public string UriByPage { get; set; }
        public ProductDto Product { get; set; }
        public IEnumerable<RatingDto>  Rating { get; set; }
        public async Task OnGet()
        {
            Product = await _productService.GetByIdAsync(Guid.Parse(Id));
            Rating = await _ratingService.GetByProductAsync(Guid.Parse(Id));
        }
        public async Task OnPost( int rating)
        {

        }
    }
}
