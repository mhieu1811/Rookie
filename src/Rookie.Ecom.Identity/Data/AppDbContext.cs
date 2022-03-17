using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Identity.Data
{
    public class AppDbContext:IdentityDbContext<AppDbUser,AppDbRole,string, IdentityUserClaim<string>, AppDbUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppDbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
   

    public class AppDbUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public ICollection<AppDbUserRole> UserRoles { get; set; }
    }
    public class AppDbUserRole : IdentityUserRole<string>
    {
        public virtual AppDbUser User { get; set; }
        public virtual AppDbRole Role { get; set; }
    }
    public class AppDbRole : IdentityRole
    {
        public ICollection<AppDbUserRole> UserRoles { get; set; }
    }
}
