using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserDto:BaseDto
    {
        [Required]
        [StringLength(maximumLength:500)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. Ví dụ: example@gmail.com")]
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }   
        public string PhoneNumber { get; set; } 
        public bool Status { get; set; }    
       /* public ICollection<UserDetailsDto> UserDetails { get; set; } 
        public ICollection<AddressDto> Address { get; set; }
        public ICollection<RatingDto> Ratings { get; set; }*/
    }
}
