using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayo.Models
{
    public class ProductColor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; } // e.g., "Small", "Medium", "Large"
        [Required]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; } // Controls the order in which sizes are displayed
        [DisplayName("Availability")]
        [Required]
        public bool IsActive { get; set; } // Whether this size is available for selection
    }

}
