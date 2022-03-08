using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserDetailsDto:BaseDto
    {
        public Guid? UserID { get; set; }
        public UserDto User { get; set; }
        public Guid? RoleID { get; set; }
/*        public RoleDto Role { get; set; }
*/    }
}
