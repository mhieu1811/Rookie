using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rookie.Ecom.Customer.Controllers
{
    public class User : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Login()
        {
            return Redirect("/");
        }
    }
}
