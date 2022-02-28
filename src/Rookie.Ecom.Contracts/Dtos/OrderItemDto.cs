using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderItemDto:BaseDto
    {

        public Guid? OrderID { get; set; }
/*        public OrderDto Order { get; set; }
*/        public Guid? ProductID{ get; set; }
/*        public ProductDto Product { get; set; }
*/        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
/*        public RatingDto Rating { get; set; }
*/
    }
}
