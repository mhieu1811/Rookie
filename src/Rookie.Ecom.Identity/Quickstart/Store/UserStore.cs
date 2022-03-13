

using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Rookie.Ecom.Identity.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Rookie.Ecom.Identity.Quickstart.Store
{
    //
    // Summary:
    //     Store for test users
    public class UserStore
    {
        private readonly List<AppDbUser> _users;

        //
        // Summary:
        //     Initializes a new instance of the IdentityServer4.Test.TestUserStore class.
        //
        // Parameters:
        //   users:
        //     The users.
        public UserStore(List<AppDbUser> users)
        {
            _users = users;
        }

        //
        // Summary:
        //     Validates the credentials.
        //
        // Parameters:
        //   username:
        //     The username.
        //
        //   password:
        //     The password.
        /*public bool ValidateCredentials(string username, string password)
        {
            AppDbUser User = FindByUsername(username);
            if (User != null)
            {
                if (string.IsNullOrWhiteSpace(User.PasswordHash) && string.IsNullOrWhiteSpace(password))
                {
                    return true;
                }

                return User.PasswordHash.Equals(password);
            }

            return false;
        }*/

        //
        // Summary:
        //     Finds the user by subject identifier.
        //
        // Parameters:
        //   subjectId:
        //     The subject identifier.
        /*public IdentityUser FindBySubjectId(string subjectId)
        {
            return _users.FirstOrDefault((IdentityUser x) => x.SubjectId == subjectId);
        }*/

        //
        // Summary:
        //     Finds the user by username.
        //
        // Parameters:
        //   username:
        //     The username.
        public AppDbUser FindByUsername(string username)
        {
            return _users.FirstOrDefault((AppDbUser x) => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        //
        // Summary:
        //     Finds the user by external provider.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        /*public IdentityUser FindByExternalProvider(string provider, string userId)
        {
            return _users.FirstOrDefault((IdentityUser x) => x.UserName == provider && x.Id == userId);
        }*/

        //
        // Summary:
        //     Automatically provisions a user.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        //
        //   claims:
        //     The claims.
/*        public IdentityUser AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            List<Claim> list = new List<Claim>();
            foreach (Claim claim in claims)
            {
                if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                {
                    list.Add(new Claim("name", claim.Value));
                }
                else if (JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.ContainsKey(claim.Type))
                {
                    list.Add(new Claim(JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap[claim.Type], claim.Value));
                }
                else
                {
                    list.Add(claim);
                }
            }

            if (!list.Any((Claim x) => x.Type == "name"))
            {
                string text = list.FirstOrDefault((Claim x) => x.Type == "id")?.Value;
                string text2 = list.FirstOrDefault((Claim x) => x.Type == "username")?.Value;
                if (text != null && text2 != null)
                {
                    list.Add(new Claim("name", text + " " + text2));
                }
                else if (text != null)
                {
                    list.Add(new Claim("name", text));
                }
                else if (text2 != null)
                {
                    list.Add(new Claim("name", text2));
                }
            }

            string text3 = CryptoRandom.CreateUniqueId(32, CryptoRandom.OutputFormat.Hex);
            string username = list.FirstOrDefault((Claim c) => c.Type == "name")?.Value ?? text3;
            IdentityUser testUser = new IdentityUser
            {
                UserName = username,
                Id = userId
              
            };
            _users.Add(testUser);
            return testUser;
        }
*/    }
}
