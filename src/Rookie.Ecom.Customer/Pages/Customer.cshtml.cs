using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using EnsureThat;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Rookie.Ecom.Customer.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public CustomerModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<CategoryDto> Category;
         public string Ten { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }
        public async Task OnGet()
        {
            Category = await _categoryService.GetByNameAsync(Keyword);
        }
    }
}
