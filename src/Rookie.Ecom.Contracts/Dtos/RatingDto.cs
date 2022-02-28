using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rookie.Ecom.Contracts.Dtos
{
    public class RatingDto:BaseDto
    {

        public Guid? UserID { get; set; }
/*        public UserDto User { get; set; }
*/
        public Guid? OrderID { get; set; }
/*        public OrderDto Order { get; set; }
*/
        public Guid? ProductID { get; set; }
/*        public ProductDto Product { get; set; }
*/        public int Rate { get; set; }
        public string Comment { get; set; }
    }
}
