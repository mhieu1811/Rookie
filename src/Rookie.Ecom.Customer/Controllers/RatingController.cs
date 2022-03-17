using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Linq;

namespace Rookie.Ecom.Customer.Controllers
{
    public class RatingController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categorytService;
        private readonly IRatingService _ratingService;

        public RatingController(IProductService productService, ICategoryService categoryService, IRatingService ratingService)
        {

            _productService = productService;
            _categorytService = categoryService;
            _ratingService = ratingService;
        }
        public IActionResult Index(string rating, string comment, string productId)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                string id = User.Claims.Where(m => m.Type == "Id").SingleOrDefault().Value.ToString();
                RatingDto rate = new RatingDto();
                rate.Id = Guid.NewGuid();
                rate.Comment = comment;
                rate.CreatedDate = DateTime.Now;
                rate.UpdatedDate = DateTime.Now;
                rate.UserID = Guid.Parse(id);
                rate.ProductID= Guid.Parse(productId);
                rate.Pubished = true;
                rate.Rate = int.Parse(rating);
                rate.FirstName = User.Claims.Where(m => m.Type == "FirstName").SingleOrDefault().Value.ToString();
                rate.LastName = User.Claims.Where(m => m.Type == "LastName").SingleOrDefault().Value.ToString();
                _ratingService.AddAsync(rate);
                return Redirect("/product/" + productId);

            }
            else
            {
                return Redirect("/usermanager?key=login");
            }
        }
    }
}
