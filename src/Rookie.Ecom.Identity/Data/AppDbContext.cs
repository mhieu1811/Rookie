using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Identity.Data
{
    public class AppDbContext:IdentityDbContext<AppDbUser>
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
    public class AppDbUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

}
