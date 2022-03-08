using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;

namespace Rookie.Ecom.Customer.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IOrderService _ordertService;

        public CartModel(IProductService productService, IOrderService orderService)
        {

            _productService = productService;
            _ordertService = orderService;
        }
        public void OnGet()
        {
        }
    }
}
