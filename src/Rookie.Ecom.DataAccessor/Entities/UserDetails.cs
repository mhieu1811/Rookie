using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class UserDetails:BaseEntity
    {
        public Guid? UserID { get; set; }
        public User User { get; set; }  
        public Guid? RoleID { get; set; }
        public Role Role { get; set; }
    }
}
