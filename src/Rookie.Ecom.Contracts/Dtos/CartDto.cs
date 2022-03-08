using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Rookie.Ecom.Contracts.Dtos
{
    public class CartDto:BaseDto
    {
        public UserDto User { get; set; }  
        public Guid? UserID { get; set; }
        public Guid? ProductID { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity    { get; set; }
    }
}
