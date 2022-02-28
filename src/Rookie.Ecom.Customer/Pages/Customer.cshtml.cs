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

        public IEnumerable<CategoryDto> Category => _categoryService.GetAllAsync().Result;
         public string Ten { get; set; }
        
        public void OnGet()
        {
            
        }
    }
}
