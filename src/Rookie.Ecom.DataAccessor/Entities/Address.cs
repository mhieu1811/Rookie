using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Address:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 1000000)]
        public string AddressLine { get; set; }  
        public Guid? UserID { get; set; }
        public User User { get; set; }
        public Guid? CityID { get; set; }
        public City City { get; set; }
    }
}
