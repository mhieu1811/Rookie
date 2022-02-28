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

namespace Rookie.Ecom.Customer.Pages.City
{
    public class CreateModel : PageModel
    {
        private readonly ICityService _cityService;
        public CreateModel(ICityService cityService)
        {
            _cityService = cityService;

        }
        [BindProperty]
        public CityDto City { get; set; }

        public void OnGet()
        {

        }
        public async Task OnPost(CityDto City)
        {
            City.Id = Guid.NewGuid();
            City.CreatedDate= DateTime.Now;
            City.UpdatedDate=DateTime.Now;
            City.Pubished = true;
            City.CreatorId = Guid.NewGuid();
            await _cityService.AddAsync(City);
        }
    }
}
