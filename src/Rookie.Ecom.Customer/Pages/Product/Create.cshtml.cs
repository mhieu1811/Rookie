using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages.Product
{
    public class CreateModel : PageModel
    {
        readonly IProductService productService;
        readonly IProductDetailsService productDetailsService;
        readonly IProductPictureService productPictureService;
        readonly ICategoryService categoryService;

        public CreateModel(IProductService _productService,ICategoryService _categoryService, IProductPictureService _productPictureService, IProductDetailsService _productDetailsService)
        {
            productService = _productService;
            productDetailsService = _productDetailsService;
            productPictureService = _productPictureService;
            categoryService = _categoryService;
        }
        public ProductDto product {get; set;}
        public List<string> details { get; set; }    
        public List<ProductPictureDto> picture { get; set; }
        public async Task OnGet()
        {

            ViewData["ListCategory"] = new SelectList(await categoryService.GetAllAsync(), "Id", "CategoryName");
        }
        public async Task OnPost(ProductDto product, List<ProductDetailsDto> details, List<ProductPictureDto> picture)
        {

        }
    }
}
