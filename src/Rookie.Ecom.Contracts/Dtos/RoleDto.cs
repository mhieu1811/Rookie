using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class RoleDto:BaseDto
    {
        public string RoleName { get; set; }
/*        ICollection<UserDetailsDto> UserDetails  { get; set; }
*/    }
}
