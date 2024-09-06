using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayo.Models
{

    namespace Tayo.Models
    {
        public class Product
        {
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string? Name { get; set; }

            public string? Description { get; set; }

            [MaxLength(255)]
            [DisplayName("Image")]
            public string? ImageUrl { get; set; }

            [Required]
            [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
            public decimal Price { get; set; }
            [DisplayName("Availabilty")]
            public bool IsAvailable { get; set; } = true;
            [DisplayName("Display Order")]
            public int DisplayOrder { get; set; }

            // Foreign key relationships to other models
            [Required]
            [DisplayName("Category")]
            public int CategoryId { get; set; }
            [ForeignKey("CategoryId")]
            public Category? Category { get; set; }

            [Required]
            [DisplayName("Collection")]
            public int CollectionId { get; set; }
            [ForeignKey("CollectionId")]
            public Collection? Collection { get; set; }
            
            [Required]
            [DisplayName("Color")]
            public int? ProductColorId { get; set; }
            [ForeignKey("ProductColorId")]
            public ProductColor? ProductColor { get; set; }

            [Required]
            [DisplayName("Size")]
            public int? ProductSizeId { get; set; }
            [ForeignKey("ProductSizeId")]
            public ProductSize? ProductSize { get; set; }
        }
    }

}
