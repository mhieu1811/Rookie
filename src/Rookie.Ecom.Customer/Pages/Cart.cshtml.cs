using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IOrderService _ordertService;

        private readonly ICartService _cartService;

        public CartModel( ICartService cartService, IProductService productService, IOrderService orderService)
        {

            _productService = productService;
            _ordertService = orderService;
            _cartService = cartService;
        }
        public IEnumerable<CartDto> Cart { get; set; }
        public async Task OnGet()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var id = identity.Claims.Where(m => m.Type == "Id").SingleOrDefault();
            if (id != null)
            {
                Cart = await _cartService.GetByUserAsync(Guid.Parse(id.Value.ToString()));
            }
        }
        /*public IActionResult OnPost()
        {
        }*/
    }
}
