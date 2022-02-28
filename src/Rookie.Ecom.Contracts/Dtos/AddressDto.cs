using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Rookie.Ecom.Contracts.Dtos
{
    public class AddressDto:BaseDto
    {
        public string AddressLine { get; set; }  
        public Guid? UserID { get; set; }
        public Guid? CityID { get; set; }
    }
}
