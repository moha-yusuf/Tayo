﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayo.Models
{
    public class ProductSize
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; } // e.g., "Small", "Medium", "Large"
        public int DisplayOrder { get; set; } // Controls the order in which ProductSizes are displayed

        public bool IsActive { get; set; } // Whether this ProductSize is available for selection
    }

}