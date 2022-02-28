using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Role:BaseEntity
    {
        [StringLength(maximumLength:50)]
        public string RoleName { get; set; }
        ICollection<UserDetails> UserDetails  { get; set; }
    }
}
