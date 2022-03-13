using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Controllers
{
    public class CartActionController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categorytService;
        private readonly ICartService _cartService;

        public CartActionController(IProductService productService, ICategoryService categoryService, ICartService cartService)
        {

            _productService = productService;
            _categorytService = categoryService;
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddToCartList(string pId)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string id = User.Claims.Where(m => m.Type == "Id").SingleOrDefault().Value.ToString();
                var check = await _cartService.GetItemCartAsync(Guid.Parse(id), Guid.Parse(pId));
                if(check != null)
                {
                    check.Quantity += 1;
                    Console.WriteLine(check.Id);
                    await _cartService.UpdateAsync(check);

                }
                else
                {
                    CartDto cart = new CartDto();
                    cart.ProductId = Guid.Parse(pId);
                    cart.Id = Guid.NewGuid();
                    cart.CreatedDate = DateTime.Now;
                    cart.UpdatedDate = DateTime.Now;
                    cart.Pubished = true;
                    cart.Quantity = 1;
                    cart.UserId = Guid.Parse(id);
                    await _cartService.AddAsync(cart);
                }
                return Redirect("/");

            }
            else
            {
                return Redirect("/usermanager?key=login");
            }
        }

        public async Task<IActionResult> AddToCartItem(string pId, string soluong)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string id = User.Claims.Where(m => m.Type == "Id").SingleOrDefault().Value.ToString();
                var check = await _cartService.GetItemCartAsync(Guid.Parse(id), Guid.Parse(pId));
                if (check != null)
                {
                    check.Quantity += int.Parse(soluong);
                    Console.WriteLine(check.Id);
                    await _cartService.UpdateAsync(check);

                }
                else
                {
                    CartDto cart = new CartDto();
                    cart.ProductId = Guid.Parse(pId);
                    cart.Id = Guid.NewGuid();
                    cart.CreatedDate = DateTime.Now;
                    cart.UpdatedDate = DateTime.Now;
                    cart.Pubished = true;
                    cart.Quantity = int.Parse(soluong);
                    cart.UserId = Guid.Parse(id);
                    await _cartService.AddAsync(cart);
                }
                return Redirect("/product/"+pId);

            }
            else
            {
                return Redirect("/usermanager?key=login");
            }
        }
    }
}
