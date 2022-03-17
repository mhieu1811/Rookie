using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rookie.Ecom.Business.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.IO;
using Rookie.Ecom.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Rookie.Ecom.Customer.Pages
{
    [Authorize]
    public class UserManagerModel : PageModel
    {
        public IUserService _userService;
        public UserManagerModel(IUserService userService)
        {

           _userService=userService;

        }

        public async Task<IActionResult> OnGet(string key)
        {
            if (key == "login")
            {
                var identity = (ClaimsIdentity)User.Identity;
                var id = identity.Claims.Where(m => m.Type == "Id").SingleOrDefault();
                /*if (id != null)
                {
                    UserDto user = _userService.GetByIdAsync(Guid.Parse(id.Value.ToString())).Result;
                    HttpContext.Session.SetString("Name", user.FirstName + " " + user.LastName);
                    HttpContext.Session.SetString("Id", user.Id.ToString());

                }*/
                var user_exist =await _userService.GetByIdAsync(Guid.Parse(id.Value.ToString()));
                if(user_exist==null)
                {
                    UserDto user = new UserDto();
                    user.UpdatedDate = DateTime.Now;
                    user.CreatedDate = DateTime.Now;
                    user.FirstName = identity.Claims.Where(m => m.Type == "FirstName").SingleOrDefault().Value;
                    user.LastName = identity.Claims.Where(m => m.Type == "LastName").SingleOrDefault().Value;
                    user.Status = true;
                    user.Email = identity.Claims.Where(m => m.Type == "Email").SingleOrDefault().Value; ;
                    user.UserName = "username";
                    user.Password ="password";
                    user.PhoneNumber = identity.Claims.Where(m => m.Type == "PhoneNumber").SingleOrDefault().Value; ;
                    user.Pubished = true;
                    user.Id = Guid.Parse(id.Value.ToString());
                    await _userService.AddAsync(user);
                }    

                return Redirect("/");
            }
            else
            {
                HttpContext.Session.Clear();
                return SignOut("Cookies", "oidc");

            }
        }
    }
}
