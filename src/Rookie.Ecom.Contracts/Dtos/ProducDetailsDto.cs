using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductDetailsDto:BaseDto
    {

        public Guid? CategoryID { get; set; }
/*        public CategoryDto Category { get; set; }
*/        public Guid? ProductID { get; set; }
/*        public ProductDto Product { get; set; }
*/
    }
}
